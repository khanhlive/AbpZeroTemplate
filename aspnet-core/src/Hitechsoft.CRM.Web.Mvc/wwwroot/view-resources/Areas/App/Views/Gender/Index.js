(function () {
    $(function () {

        var _$genderTable = $('#GenderTable');
        var _genderService = abp.services.app.gender;
		
        $('.date-picker').datetimepicker({
            locale: abp.localization.currentLanguage.name,
            format: 'L'
        });

        var _permissions = {
            create: abp.auth.hasPermission('Pages.Gender.Create'),
            edit: abp.auth.hasPermission('Pages.Gender.Edit'),
            'delete': abp.auth.hasPermission('Pages.Gender.Delete')
        };

         var _createOrEditModal = new app.ModalManager({
                    viewUrl: abp.appPath + 'App/Gender/CreateOrEditModal',
                    scriptUrl: abp.appPath + 'view-resources/Areas/App/Views/Gender/_CreateOrEditModal.js',
                    modalClass: 'CreateOrEditGenderModal'
                });
                   

		 var _viewGenderModal = new app.ModalManager({
            viewUrl: abp.appPath + 'App/Gender/ViewgenderModal',
            modalClass: 'ViewGenderModal'
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

        var dataTable = _$genderTable.DataTable({
            paging: true,
            serverSide: true,
            processing: true,
            listAction: {
                ajaxFunction: _genderService.getAll,
                inputFilter: function () {
                    return {
					filter: $('#GenderTableFilter').val()
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
                                    _viewGenderModal.open({ id: data.record.gender.id });
                                }
                        },
						{
                            text: app.localize('Edit'),
                            iconStyle: 'far fa-edit mr-2',
                            visible: function () {
                                return _permissions.edit;
                            },
                            action: function (data) {
                            _createOrEditModal.open({ id: data.record.gender.id });                                
                            }
                        }, 
						{
                            text: app.localize('Delete'),
                            iconStyle: 'far fa-trash-alt mr-2',
                            visible: function () {
                                return _permissions.delete;
                            },
                            action: function (data) {
                                deleteGender(data.record.gender);
                            }
                        }]
                    }
                },
					{
						targets: 2,
						 data: "gender.code",
						 name: "code"   
					},
					{
						targets: 3,
						 data: "gender.name",
						 name: "name"   
					},
					{
						targets: 4,
						 data: "gender.isDeleted",
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

        function getGender() {
            dataTable.ajax.reload();
        }

        function deleteGender(gender) {
            abp.message.confirm(
                '',
                app.localize('AreYouSure'),
                function (isConfirmed) {
                    if (isConfirmed) {
                        _genderService.delete({
                            id: gender.id
                        }).done(function () {
                            getGender(true);
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

        $('#CreateNewGenderButton').click(function () {
            _createOrEditModal.open();
        });        

		$('#ExportToExcelButton').click(function () {
            _genderService
                .getGenderToExcel({
				filter : $('#GenderTableFilter').val()
				})
                .done(function (result) {
                    app.downloadTempFile(result);
                });
        });

        abp.event.on('app.createOrEditGenderModalSaved', function () {
            getGender();
        });

		$('#GetGenderButton').click(function (e) {
            e.preventDefault();
            getGender();
        });

		$(document).keypress(function(e) {
		  if(e.which === 13) {
			getGender();
		  }
		});
		
		
		
    });
})();
