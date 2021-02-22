(function ($) {
    app.modals.CreateOrEditEthnicityModal = function () {

        var _ethnicitiesService = abp.services.app.ethnicities;

        var _modalManager;
        var _$ethnicityInformationForm = null;

		

        this.init = function (modalManager) {
            _modalManager = modalManager;

			var modal = _modalManager.getModal();
            modal.find('.date-picker').datetimepicker({
                locale: abp.localization.currentLanguage.name,
                format: 'L'
            });

            _$ethnicityInformationForm = _modalManager.getModal().find('form[name=EthnicityInformationsForm]');
            _$ethnicityInformationForm.validate();
        };

		  

        this.save = function () {
            if (!_$ethnicityInformationForm.valid()) {
                return;
            }

            var ethnicity = _$ethnicityInformationForm.serializeFormToObject();
			
			 _modalManager.setBusy(true);
			 _ethnicitiesService.createOrEdit(
				ethnicity
			 ).done(function () {
               abp.notify.info(app.localize('SavedSuccessfully'));
               _modalManager.close();
               abp.event.trigger('app.createOrEditEthnicityModalSaved');
			 }).always(function () {
               _modalManager.setBusy(false);
			});
        };
    };
})(jQuery);