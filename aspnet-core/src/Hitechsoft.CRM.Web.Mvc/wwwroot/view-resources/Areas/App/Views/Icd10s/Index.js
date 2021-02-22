(function () {
    $(function () {

        var _$icd10sTable = $('#Icd10sTable');
        var _icd10sService = abp.services.app.icd10s;
		
        $('.date-picker').datetimepicker({
            locale: abp.localization.currentLanguage.name,
            format: 'L'
        });

        var _permissions = {
            create: abp.auth.hasPermission('Pages.Icd10s.Create'),
            edit: abp.auth.hasPermission('Pages.Icd10s.Edit'),
            'delete': abp.auth.hasPermission('Pages.Icd10s.Delete')
        };

         var _createOrEditModal = new app.ModalManager({
                    viewUrl: abp.appPath + 'App/Icd10s/CreateOrEditModal',
                    scriptUrl: abp.appPath + 'view-resources/Areas/App/Views/Icd10s/_CreateOrEditModal.js',
                    modalClass: 'CreateOrEditIcd10Modal'
                });
                   

		 var _viewIcd10Modal = new app.ModalManager({
            viewUrl: abp.appPath + 'App/Icd10s/Viewicd10Modal',
            modalClass: 'ViewIcd10Modal'
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

        var dataTable = _$icd10sTable.DataTable({
            paging: true,
            serverSide: true,
            processing: true,
            listAction: {
                ajaxFunction: _icd10sService.getAll,
                inputFilter: function () {
                    return {
					filter: $('#Icd10sTableFilter').val(),
					codeFilter: $('#CodeFilterId').val(),
					nameFilter: $('#NameFilterId').val(),
					diseaseChapterCodeFilter: $('#DiseaseChapterCodeFilterId').val(),
					diseaseChapterNameFilter: $('#DiseaseChapterNameFilterId').val(),
					wHOeNameFilter: $('#WHOeNameFilterId').val(),
					wHONameFilter: $('#WHONameFilterId').val(),
					minStatusFilter: $('#MinStatusFilterId').val(),
					maxStatusFilter: $('#MaxStatusFilterId').val()
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
                                    _viewIcd10Modal.open({ id: data.record.icd10.id });
                                }
                        },
						{
                            text: app.localize('Edit'),
                            iconStyle: 'far fa-edit mr-2',
                            visible: function () {
                                return _permissions.edit;
                            },
                            action: function (data) {
                            _createOrEditModal.open({ id: data.record.icd10.id });                                
                            }
                        }, 
						{
                            text: app.localize('Delete'),
                            iconStyle: 'far fa-trash-alt mr-2',
                            visible: function () {
                                return _permissions.delete;
                            },
                            action: function (data) {
                                deleteIcd10(data.record.icd10);
                            }
                        }]
                    }
                },
					{
						targets: 2,
						 data: "icd10.code",
						 name: "code"   
					},
					{
						targets: 3,
						 data: "icd10.name",
						 name: "name"   
					},
					{
						targets: 4,
						 data: "icd10.diseaseChapterCode",
						 name: "diseaseChapterCode"   
					},
					{
						targets: 5,
						 data: "icd10.diseaseChapterName",
						 name: "diseaseChapterName"   
					},
					{
						targets: 6,
						 data: "icd10.whOeName",
						 name: "whOeName"   
					},
					{
						targets: 7,
						 data: "icd10.whoName",
						 name: "whoName"   
					},
					{
						targets: 8,
						 data: "icd10.status",
						 name: "status"   
					}
            ]
        });

        function getIcd10s() {
            dataTable.ajax.reload();
        }

        function deleteIcd10(icd10) {
            abp.message.confirm(
                '',
                app.localize('AreYouSure'),
                function (isConfirmed) {
                    if (isConfirmed) {
                        _icd10sService.delete({
                            id: icd10.id
                        }).done(function () {
                            getIcd10s(true);
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

        $('#CreateNewIcd10Button').click(function () {
            _createOrEditModal.open();
        });        

		$('#ExportToExcelButton').click(function () {
            _icd10sService
                .getIcd10sToExcel({
				filter : $('#Icd10sTableFilter').val(),
					codeFilter: $('#CodeFilterId').val(),
					nameFilter: $('#NameFilterId').val(),
					diseaseChapterCodeFilter: $('#DiseaseChapterCodeFilterId').val(),
					diseaseChapterNameFilter: $('#DiseaseChapterNameFilterId').val(),
					wHOeNameFilter: $('#WHOeNameFilterId').val(),
					wHONameFilter: $('#WHONameFilterId').val(),
					minStatusFilter: $('#MinStatusFilterId').val(),
					maxStatusFilter: $('#MaxStatusFilterId').val()
				})
                .done(function (result) {
                    app.downloadTempFile(result);
                });
        });

        abp.event.on('app.createOrEditIcd10ModalSaved', function () {
            getIcd10s();
        });

		$('#GetIcd10sButton').click(function (e) {
            e.preventDefault();
            getIcd10s();
        });

		$(document).keypress(function(e) {
		  if(e.which === 13) {
			getIcd10s();
		  }
		});
		
		
		
    });
})();
