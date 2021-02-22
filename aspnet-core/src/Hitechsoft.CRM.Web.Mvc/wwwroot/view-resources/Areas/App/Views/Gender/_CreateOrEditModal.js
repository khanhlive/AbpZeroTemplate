(function ($) {
    app.modals.CreateOrEditGenderModal = function () {

        var _genderService = abp.services.app.gender;

        var _modalManager;
        var _$genderInformationForm = null;

		

        this.init = function (modalManager) {
            _modalManager = modalManager;

			var modal = _modalManager.getModal();
            modal.find('.date-picker').datetimepicker({
                locale: abp.localization.currentLanguage.name,
                format: 'L'
            });

            _$genderInformationForm = _modalManager.getModal().find('form[name=GenderInformationsForm]');
            _$genderInformationForm.validate();
        };

		  

        this.save = function () {
            if (!_$genderInformationForm.valid()) {
                return;
            }

            var gender = _$genderInformationForm.serializeFormToObject();
			
			 _modalManager.setBusy(true);
			 _genderService.createOrEdit(
				gender
			 ).done(function () {
               abp.notify.info(app.localize('SavedSuccessfully'));
               _modalManager.close();
               abp.event.trigger('app.createOrEditGenderModalSaved');
			 }).always(function () {
               _modalManager.setBusy(false);
			});
        };
    };
})(jQuery);