(function ($) {
    app.modals.CreateOrEditMedicalSpecialtyModal = function () {

        var _medicalSpecialtiesService = abp.services.app.medicalSpecialties;

        var _modalManager;
        var _$medicalSpecialtyInformationForm = null;

		

        this.init = function (modalManager) {
            _modalManager = modalManager;

			var modal = _modalManager.getModal();
            modal.find('.date-picker').datetimepicker({
                locale: abp.localization.currentLanguage.name,
                format: 'L'
            });

            _$medicalSpecialtyInformationForm = _modalManager.getModal().find('form[name=MedicalSpecialtyInformationsForm]');
            _$medicalSpecialtyInformationForm.validate();
        };

		  

        this.save = function () {
            if (!_$medicalSpecialtyInformationForm.valid()) {
                return;
            }

            var medicalSpecialty = _$medicalSpecialtyInformationForm.serializeFormToObject();
			
			 _modalManager.setBusy(true);
			 _medicalSpecialtiesService.createOrEdit(
				medicalSpecialty
			 ).done(function () {
               abp.notify.info(app.localize('SavedSuccessfully'));
               _modalManager.close();
               abp.event.trigger('app.createOrEditMedicalSpecialtyModalSaved');
			 }).always(function () {
               _modalManager.setBusy(false);
			});
        };
    };
})(jQuery);