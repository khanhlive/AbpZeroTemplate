(function () {
    $(function () {

        var _$medicinalTypesTable = $('#MedicinalTypesTable');
        var _medicinalTypesService = abp.services.app.medicinalTypes;
		
        $('.date-picker').datetimepicker({
            locale: abp.localization.currentLanguage.name,
            format: 'L'
        });

        var _permissions = {
            create: abp.auth.hasPermission('Pages.Administration.MedicinalTypes.Create'),
            edit: abp.auth.hasPermission('Pages.Administration.MedicinalTypes.Edit'),
            'delete': abp.auth.hasPermission('Pages.Administration.MedicinalTypes.Delete')
        };

         var _createOrEditModal = new app.ModalManager({
                    viewUrl: abp.appPath + 'App/MedicinalTypes/CreateOrEditModal',
                    scriptUrl: abp.appPath + 'view-resources/Areas/App/Views/MedicinalTypes/_CreateOrEditModal.js',
                    modalClass: 'CreateOrEditMedicinalTypeModal'
                });
                   

		 var _viewMedicinalTypeModal = new app.ModalManager({
            viewUrl: abp.appPath + 'App/MedicinalTypes/ViewmedicinalTypeModal',
            modalClass: 'ViewMedicinalTypeModal'
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

        var dataTable = _$medicinalTypesTable.DataTable({
            paging: true,
            serverSide: true,
            processing: true,
            listAction: {
                ajaxFunction: _medicinalTypesService.getAll,
                inputFilter: function () {
                    return {
					filter: $('#MedicinalTypesTableFilter').val()
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
                                    _viewMedicinalTypeModal.open({ id: data.record.medicinalType.id });
                                }
                        },
						{
                            text: app.localize('Edit'),
                            iconStyle: 'far fa-edit mr-2',
                            visible: function () {
                                return _permissions.edit;
                            },
                            action: function (data) {
                            _createOrEditModal.open({ id: data.record.medicinalType.id });                                
                            }
                        }, 
						{
                            text: app.localize('Delete'),
                            iconStyle: 'far fa-trash-alt mr-2',
                            visible: function () {
                                return _permissions.delete;
                            },
                            action: function (data) {
                                deleteMedicinalType(data.record.medicinalType);
                            }
                        }]
                    }
                },
					{
						targets: 2,
						 data: "medicinalType.code",
						 name: "code"   
					},
					{
						targets: 3,
						 data: "medicinalType.name",
						 name: "name"   
					},
					{
						targets: 4,
						 data: "medicinalType.description",
						 name: "description"   
					},
					{
						targets: 5,
						 data: "medicinalType.status",
						 name: "status"   
					},
					{
						targets: 6,
						 data: "medicinalType.isDeleted",
						 name: "isDeleted"  ,
						render: function (isDeleted) {
							if (isDeleted) {
								return '<div class="text-center"><i class="fa fa-check text-success" title="True"></i></div>';
							}
							return '<div class="text-center"><i class="fa fa-times-circle" title="False"></i></div>';
					}
			 
					}
            ]
        });

        function getMedicinalTypes() {
            dataTable.ajax.reload();
        }

        function deleteMedicinalType(medicinalType) {
            abp.message.confirm(
                '',
                app.localize('AreYouSure'),
                function (isConfirmed) {
                    if (isConfirmed) {
                        _medicinalTypesService.delete({
                            id: medicinalType.id
                        }).done(function () {
                            getMedicinalTypes(true);
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

        $('#CreateNewMedicinalTypeButton').click(function () {
            _createOrEditModal.open();
        });        

		$('#ExportToExcelButton').click(function () {
            _medicinalTypesService
                .getMedicinalTypesToExcel({
				filter : $('#MedicinalTypesTableFilter').val()
				})
                .done(function (result) {
                    app.downloadTempFile(result);
                });
        });

        abp.event.on('app.createOrEditMedicinalTypeModalSaved', function () {
            getMedicinalTypes();
        });

		$('#GetMedicinalTypesButton').click(function (e) {
            e.preventDefault();
            getMedicinalTypes();
        });

		$(document).keypress(function(e) {
		  if(e.which === 13) {
			getMedicinalTypes();
		  }
		});
		
		
		
    });
})();
