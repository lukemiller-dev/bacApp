namespace AlcoholApp.Services {
    export class ModalService {
        constructor(public $uibModal: ng.ui.bootstrap.IModalService) { }
        public openModal(html) {
            this.$uibModal.open({
                templateUrl: `/ngApp/views/${html}`,
                controller: AlcoholApp.Controllers.ModalController,
                controllerAs: 'modal',
                size: 'md'
            });
        }
    }
 
    angular.module("AlcoholApp").service("ModalService", ModalService);
 }
