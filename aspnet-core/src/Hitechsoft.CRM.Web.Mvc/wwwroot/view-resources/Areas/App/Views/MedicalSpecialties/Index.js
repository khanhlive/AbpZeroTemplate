(function () {
    $(function () {

        var _$medicalSpecialtiesTable = $('#MedicalSpecialtiesTable');
        var _medicalSpecialtiesService = abp.services.app.medicalSpecialties;
		
        $('.date-picker').datetimepicker({
            locale: abp.localization.currentLanguage.name,
            format: 'L'
        });

        var _permissions = {
            create: abp.auth.hasPermission('Pages.MedicalSpecialties.Create'),
            edit: abp.auth.hasPermission('Pages.MedicalSpecialties.Edit'),
            'delete': abp.auth.hasPermission('Pages.MedicalSpecialties.Delete')
        };

         var _createOrEditModal = new app.ModalManager({
                    viewUrl: abp.appPath + 'App/MedicalSpecialties/CreateOrEditModal',
                    scriptUrl: abp.appPath + 'view-resources/Areas/App/Views/MedicalSpecialties/_CreateOrEditModal.js',
                    modalClass: 'CreateOrEditMedicalSpecialtyModal'
                });
                   

		 var _viewMedicalSpecialtyModal = new app.ModalManager({
            viewUrl: abp.appPath + 'App/MedicalSpecialties/ViewmedicalSpecialtyModal',
            modalClass: 'ViewMedicalSpecialtyModal'
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

        var dataTable = _$medicalSpecialtiesTable.DataTable({
            paging: true,
            serverSide: true,
            processing: true,
            listAction: {
                ajaxFunction: _medicalSpecialtiesService.getAll,
                inputFilter: function () {
                    return {
					filter: $('#MedicalSpecialtiesTableFilter').val(),
					codeFilter: $('#CodeFilterId').val(),
					nameFilter: $('#NameFilterId').val(),
					fullnameFilter: $('#FullnameFilterId').val(),
					decisionCodeFilter: $('#DecisionCodeFilterId').val(),
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
                                    _viewMedicalSpecialtyModal.open({ id: data.record.medicalSpecialty.id });
                                }
                        },
						{
                            text: app.localize('Edit'),
                            iconStyle: 'far fa-edit mr-2',
                            visible: function () {
                                return _permissions.edit;
                            },
                            action: function (data) {
                            _createOrEditModal.open({ id: data.record.medicalSpecialty.id });                                
                            }
                        }, 
						{
                            text: app.localize('Delete'),
                            iconStyle: 'far fa-trash-alt mr-2',
                            visible: function () {
                                return _permissions.delete;
                            },
                            action: function (data) {
                                deleteMedicalSpecialty(data.record.medicalSpecialty);
                            }
                        }]
                    }
                },
					{
						targets: 2,
						 data: "medicalSpecialty.code",
						 name: "code"   
					},
					{
						targets: 3,
						 data: "medicalSpecialty.name",
						 name: "name"   
					},
					{
						targets: 4,
						 data: "medicalSpecialty.fullname",
						 name: "fullname"   
					},
					{
						targets: 5,
						 data: "medicalSpecialty.decisionCode",
						 name: "decisionCode"   
					},
					{
						targets: 6,
						 data: "medicalSpecialty.status",
						 name: "status"   
					}
            ]
        });

        function getMedicalSpecialties() {
            dataTable.ajax.reload();
        }

        function deleteMedicalSpecialty(medicalSpecialty) {
            abp.message.confirm(
                '',
                app.localize('AreYouSure'),
                function (isConfirmed) {
                    if (isConfirmed) {
                        _medicalSpecialtiesService.delete({
                            id: medicalSpecialty.id
                        }).done(function () {
                            getMedicalSpecialties(true);
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

        $('#CreateNewMedicalSpecialtyButton').click(function () {
            _createOrEditModal.open();
        });        

		$('#ExportToExcelButton').click(function () {
            _medicalSpecialtiesService
                .getMedicalSpecialtiesToExcel({
				filter : $('#MedicalSpecialtiesTableFilter').val(),
					codeFilter: $('#CodeFilterId').val(),
					nameFilter: $('#NameFilterId').val(),
					fullnameFilter: $('#FullnameFilterId').val(),
					decisionCodeFilter: $('#DecisionCodeFilterId').val(),
					minStatusFilter: $('#MinStatusFilterId').val(),
					maxStatusFilter: $('#MaxStatusFilterId').val()
				})
                .done(function (result) {
                    app.downloadTempFile(result);
                });
        });

        abp.event.on('app.createOrEditMedicalSpecialtyModalSaved', function () {
            getMedicalSpecialties();
        });

		$('#GetMedicalSpecialtiesButton').click(function (e) {
            e.preventDefault();
            getMedicalSpecialties();
        });

		$(document).keypress(function(e) {
		  if(e.which === 13) {
			getMedicalSpecialties();
		  }
		});
		
		
		
    });
})();
