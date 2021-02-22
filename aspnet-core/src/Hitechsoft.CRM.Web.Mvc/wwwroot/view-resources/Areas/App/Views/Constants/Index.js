(function () {
    $(function () {

        var _$constantsTable = $('#ConstantsTable');
        var _constantsService = abp.services.app.constants;
		
        $('.date-picker').datetimepicker({
            locale: abp.localization.currentLanguage.name,
            format: 'L'
        });

        var _permissions = {
            create: abp.auth.hasPermission('Pages.Constants.Create'),
            edit: abp.auth.hasPermission('Pages.Constants.Edit'),
            'delete': abp.auth.hasPermission('Pages.Constants.Delete')
        };

         var _createOrEditModal = new app.ModalManager({
                    viewUrl: abp.appPath + 'App/Constants/CreateOrEditModal',
                    scriptUrl: abp.appPath + 'view-resources/Areas/App/Views/Constants/_CreateOrEditModal.js',
                    modalClass: 'CreateOrEditConstantModal'
                });
                   

		 var _viewConstantModal = new app.ModalManager({
            viewUrl: abp.appPath + 'App/Constants/ViewconstantModal',
            modalClass: 'ViewConstantModal'
        });

		
		

        var getDateFilter = function (element) {
            if (element.data("DateTimePicker").date() == null) {
                return null;
            }
            return element.data("DateTimePicker").date().format("YYYY-MM-DDT00:00:00Z"); 
        }
        
        var getMaxDateFilter = function (element) {
            if (element.data("DateTimePicker").date() == null) {
                return null;
            }
            return element.data("DateTimePicker").date().format("YYYY-MM-DDT23:59:59Z"); 
        }

        var dataTable = _$constantsTable.DataTable({
            paging: true,
            serverSide: true,
            processing: true,
            listAction: {
                ajaxFunction: _constantsService.getAll,
                inputFilter: function () {
                    return {
					filter: $('#ConstantsTableFilter').val(),
					codeFilter: $('#CodeFilterId').val(),
					nameFilter: $('#NameFilterId').val(),
					descriptionFilter: $('#DescriptionFilterId').val(),
					minTypeFilter: $('#MinTypeFilterId').val(),
					maxTypeFilter: $('#MaxTypeFilterId').val()
                    };
                }
            },
            columnDefs: [
                {
                    className: 'control responsive',
                    orderable: false,
                    render: function () {
                        return '';
                    },
                    targets: 0
                },
                {
                    width: 120,
                    targets: 1,
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
                                iconStyle: 'far fa-eye mr-2',
                                action: function (data) {
                                    _viewConstantModal.open({ id: data.record.constant.id });
                                }
                        },
						{
                            text: app.localize('Edit'),
                            iconStyle: 'far fa-edit mr-2',
                            visible: function () {
                                return _permissions.edit;
                            },
                            action: function (data) {
                            _createOrEditModal.open({ id: data.record.constant.id });                                
                            }
                        }, 
						{
                            text: app.localize('Delete'),
                            iconStyle: 'far fa-trash-alt mr-2',
                            visible: function () {
                                return _permissions.delete;
                            },
                            action: function (data) {
                                deleteConstant(data.record.constant);
                            }
                        }]
                    }
                },
					{
						targets: 2,
						 data: "constant.code",
						 name: "code"   
					},
					{
						targets: 3,
						 data: "constant.name",
						 name: "name"   
					},
					{
						targets: 4,
						 data: "constant.description",
						 name: "description"   
					},
					{
						targets: 5,
						 data: "constant.type",
						 name: "type"   
					}
            ]
        });

        function getConstants() {
            dataTable.ajax.reload();
        }

        function deleteConstant(constant) {
            abp.message.confirm(
                '',
                app.localize('AreYouSure'),
                function (isConfirmed) {
                    if (isConfirmed) {
                        _constantsService.delete({
                            id: constant.id
                        }).done(function () {
                            getConstants(true);
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

        $('#CreateNewConstantButton').click(function () {
            _createOrEditModal.open();
        });        

		$('#ExportToExcelButton').click(function () {
            _constantsService
                .getConstantsToExcel({
				filter : $('#ConstantsTableFilter').val(),
					codeFilter: $('#CodeFilterId').val(),
					nameFilter: $('#NameFilterId').val(),
					descriptionFilter: $('#DescriptionFilterId').val(),
					minTypeFilter: $('#MinTypeFilterId').val(),
					maxTypeFilter: $('#MaxTypeFilterId').val()
				})
                .done(function (result) {
                    app.downloadTempFile(result);
                });
        });

        abp.event.on('app.createOrEditConstantModalSaved', function () {
            getConstants();
        });

		$('#GetConstantsButton').click(function (e) {
            e.preventDefault();
            getConstants();
        });

		$(document).keypress(function(e) {
		  if(e.which === 13) {
			getConstants();
		  }
		});
		
		
		
    });
})();
