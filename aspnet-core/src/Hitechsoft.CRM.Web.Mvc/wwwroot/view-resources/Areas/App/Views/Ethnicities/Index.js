(function () {
    $(function () {

        var _$ethnicitiesTable = $('#EthnicitiesTable');
        var _ethnicitiesService = abp.services.app.ethnicities;

        $('.date-picker').datetimepicker({
            locale: abp.localization.currentLanguage.name,
            format: 'L'
        });

        var _permissions = {
            create: abp.auth.hasPermission('Pages.Administration.Ethnicities.Create'),
            edit: abp.auth.hasPermission('Pages.Administration.Ethnicities.Edit'),
            'delete': abp.auth.hasPermission('Pages.Administration.Ethnicities.Delete')
        };

        var _createOrEditModal = new app.ModalManager({
            viewUrl: abp.appPath + 'App/Ethnicities/CreateOrEditModal',
            scriptUrl: abp.appPath + 'view-resources/Areas/App/Views/Ethnicities/_CreateOrEditModal.js',
            modalClass: 'CreateOrEditEthnicityModal'
        });

        var _viewEthnicityModal = new app.ModalManager({
            viewUrl: abp.appPath + 'App/Ethnicities/ViewethnicityModal',
            modalClass: 'ViewEthnicityModal'
        });




        var getDateFilter = function (element) {
            if (element.data("DateTimePicker").date() == null) {
                return null;
            }
            return element.data("DateTimePicker").date().format("YYYY-MM-DDT00:00:00Z");
        }

        var dataTable = _$ethnicitiesTable.DataTable({
            paging: true,
            serverSide: true,
            processing: true,
            listAction: {
                ajaxFunction: _ethnicitiesService.getAll,
                inputFilter: function () {
                    return {
                        filter: $('#EthnicitiesTableFilter').val(),
                        codeFilter: $('#CodeFilterId').val(),
                        nameFilter: $('#NameFilterId').val(),
                        descriptionFilter: $('#DescriptionFilterId').val(),
                        minStatusFilter: $('#MinStatusFilterId').val(),
                        maxStatusFilter: $('#MaxStatusFilterId').val(),
                        isDeletedFilter: $('#IsDeletedFilterId').val()
                    };
                }
            },
            columnDefs: [
                {
                    width: 120,
                    targets: 0,
                    data: null,
                    orderable: false,
                    autoWidth: false,
                    defaultContent: '',
                    rowAction: {
                        cssClass: 'btn btn-brand dropdown-toggle',
                        text: '<i class="fa fa-cog"></i> ' + app.localize('Actions') + ' <span class="caret"></span>',
                        items: [
                            {
                                text: app.localize('View'),
                                action: function (data) {
                                    _viewEthnicityModal.open({ id: data.record.ethnicity.id });
                                }
                            },
                            {
                                text: app.localize('Edit'),
                                visible: function () {
                                    return _permissions.edit;
                                },
                                action: function (data) {
                                    _createOrEditModal.open({ id: data.record.ethnicity.id });
                                }
                            },
                            {
                                text: app.localize('Delete'),
                                visible: function () {
                                    return _permissions.delete;
                                },
                                action: function (data) {
                                    deleteEthnicity(data.record.ethnicity);
                                }
                            }]
                    }
                },
                {
                    targets: 1,
                    data: "ethnicity.code",
                    name: "code"
                },
                {
                    targets: 2,
                    data: "ethnicity.name",
                    name: "name"
                },
                {
                    targets: 3,
                    data: "ethnicity.description",
                    name: "description"
                },
                {
                    targets: 4,
                    data: "ethnicity.status",
                    name: "status"
                },
                //{
                //    targets: 5,
                //    data: "ethnicity.isDeleted",
                //    name: "isDeleted",
                //    render: function (isDeleted) {
                //        if (isDeleted) {
                //            return '<div class="text-center"><i class="fa fa-check text-success" title="True"></i></div>';
                //        }
                //        return '<div class="text-center"><i class="fa fa-times-circle" title="False"></i></div>';
                //    }

                //}
            ]
        });

        function getEthnicities() {
            dataTable.ajax.reload();
        }

        function deleteEthnicity(ethnicity) {
            abp.message.confirm(
                '',
                app.localize('AreYouSure'),
                function (isConfirmed) {
                    if (isConfirmed) {
                        _ethnicitiesService.delete({
                            id: ethnicity.id
                        }).done(function () {
                            getEthnicities(true);
                            abp.notify.success(app.localize('SuccessfullyDeleted'));
                        });
                    }
                }
            );
        }

        $('#ShowAdvancedFiltersSpan').click(function () {
            $('#ShowAdvancedFiltersSpan').hide();
            $('#HideAdvancedFiltersSpan').show();
            $('#AdvacedAuditFiltersArea').slideDown();
        });

        $('#HideAdvancedFiltersSpan').click(function () {
            $('#HideAdvancedFiltersSpan').hide();
            $('#ShowAdvancedFiltersSpan').show();
            $('#AdvacedAuditFiltersArea').slideUp();
        });

        $('#CreateNewEthnicityButton').click(function () {
            _createOrEditModal.open();
        });

        $('#ExportToExcelButton').click(function () {
            _ethnicitiesService
                .getEthnicitiesToExcel({
                    filter: $('#EthnicitiesTableFilter').val(),
                    codeFilter: $('#CodeFilterId').val(),
                    nameFilter: $('#NameFilterId').val(),
                    descriptionFilter: $('#DescriptionFilterId').val(),
                    minStatusFilter: $('#MinStatusFilterId').val(),
                    maxStatusFilter: $('#MaxStatusFilterId').val(),
                    isDeletedFilter: $('#IsDeletedFilterId').val()
                })
                .done(function (result) {
                    app.downloadTempFile(result);
                });
        });

        abp.event.on('app.createOrEditEthnicityModalSaved', function () {
            getEthnicities();
        });

        $('#GetEthnicitiesButton').click(function (e) {
            e.preventDefault();
            getEthnicities();
        });

        $(document).keypress(function (e) {
            if (e.which === 13) {
                getEthnicities();
            }
        });
    });
})();