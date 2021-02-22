(function ($) {
    app.modals.CreateOrEditConstantModal = function () {

        var _constantsService = abp.services.app.constants;

        var _modalManager;
        var _$constantInformationForm = null;

		

        this.init = function (modalManager) {
            _modalManager = modalManager;

			var modal = _modalManager.getModal();
            modal.find('.date-picker').datetimepicker({
                locale: abp.localization.currentLanguage.name,
                format: 'L'
            });

            _$constantInformationForm = _modalManager.getModal().find('form[name=ConstantInformationsForm]');
            _$constantInformationForm.validate();
        };

		  

        this.save = function () {
            if (!_$constantInformationForm.valid()) {
                return;
            }

            var constant = _$constantInformationForm.serializeFormToObject();
			
			 _modalManager.setBusy(true);
			 _constantsService.createOrEdit(
				constant
			 ).done(function () {
               abp.notify.info(app.localize('SavedSuccessfully'));
               _modalManager.close();
               abp.event.trigger('app.createOrEditConstantModalSaved');
			 }).always(function () {
               _modalManager.setBusy(false);
			});
        };
    };
})(jQuery);