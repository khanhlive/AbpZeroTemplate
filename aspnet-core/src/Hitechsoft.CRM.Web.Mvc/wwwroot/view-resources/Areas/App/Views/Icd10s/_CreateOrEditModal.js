(function ($) {
    app.modals.CreateOrEditIcd10Modal = function () {

        var _icd10sService = abp.services.app.icd10s;

        var _modalManager;
        var _$icd10InformationForm = null;

		

        this.init = function (modalManager) {
            _modalManager = modalManager;

			var modal = _modalManager.getModal();
            modal.find('.date-picker').datetimepicker({
                locale: abp.localization.currentLanguage.name,
                format: 'L'
            });

            _$icd10InformationForm = _modalManager.getModal().find('form[name=Icd10InformationsForm]');
            _$icd10InformationForm.validate();
        };

		  

        this.save = function () {
            if (!_$icd10InformationForm.valid()) {
                return;
            }

            var icd10 = _$icd10InformationForm.serializeFormToObject();
			
			 _modalManager.setBusy(true);
			 _icd10sService.createOrEdit(
				icd10
			 ).done(function () {
               abp.notify.info(app.localize('SavedSuccessfully'));
               _modalManager.close();
               abp.event.trigger('app.createOrEditIcd10ModalSaved');
			 }).always(function () {
               _modalManager.setBusy(false);
			});
        };
    };
})(jQuery);