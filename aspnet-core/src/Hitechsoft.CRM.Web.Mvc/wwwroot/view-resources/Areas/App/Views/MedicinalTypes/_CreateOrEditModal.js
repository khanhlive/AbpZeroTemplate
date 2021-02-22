(function ($) {
    app.modals.CreateOrEditMedicinalTypeModal = function () {

        var _medicinalTypesService = abp.services.app.medicinalTypes;

        var _modalManager;
        var _$medicinalTypeInformationForm = null;

		

        this.init = function (modalManager) {
            _modalManager = modalManager;

			var modal = _modalManager.getModal();
            modal.find('.date-picker').datetimepicker({
                locale: abp.localization.currentLanguage.name,
                format: 'L'
            });

            _$medicinalTypeInformationForm = _modalManager.getModal().find('form[name=MedicinalTypeInformationsForm]');
            _$medicinalTypeInformationForm.validate();
        };

		  

        this.save = function () {
            if (!_$medicinalTypeInformationForm.valid()) {
                return;
            }

            var medicinalType = _$medicinalTypeInformationForm.serializeFormToObject();
			
			 _modalManager.setBusy(true);
			 _medicinalTypesService.createOrEdit(
				medicinalType
			 ).done(function () {
               abp.notify.info(app.localize('SavedSuccessfully'));
               _modalManager.close();
               abp.event.trigger('app.createOrEditMedicinalTypeModalSaved');
			 }).always(function () {
               _modalManager.setBusy(false);
			});
        };
    };
})(jQuery);