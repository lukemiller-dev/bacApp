namespace AlcoholApp.Controllers {

    export class HomeController {
        constructor(public $http: ng.IHttpService, public $state: ng.ui.IStateService, public $uibModal: ng.ui.bootstrap.IModalService, public ModalService: AlcoholApp.Services.ModalService) { }
    }

    export class ModalController {
        public loginUser;

        constructor(public $http: ng.IHttpService, public $state: ng.ui.IStateService, public $uibModalInstance: ng.ui.bootstrap.IModalServiceInstance, public accountService: AlcoholApp.Services.AccountService) { }
        //added accountService and login method
        public login() {
            this.accountService.login(this.loginUser);
        } 

        public closeModal() {
            this.$uibModalInstance.close();
        }
    }

    export class MainAccountController {

    }

    export class AlcoholController {
        public alcohols;

        constructor(public $http: ng.IHttpService, public $state: ng.ui.IStateService) {
            $http.get('api/alcohols').then((res) => {
                this.alcohols = res.data;
            })
        }

        public addAlcohol(alcohol) {
            this.$http.post('api/alcohols', alcohol).then((res) => {
                this.$state.reload();
            })
        }
    }
        


    export class SecretController {
        public secrets;

        constructor($http: ng.IHttpService) {
            $http.get('/api/secrets').then((results) => {
                this.secrets = results.data;
            });
        }
    }


    export class AboutController {
        public message = 'Hello from the about page!';
    }

}
