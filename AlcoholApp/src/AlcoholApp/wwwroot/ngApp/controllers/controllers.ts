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
        private drinks;
        private drinkId;
        private favorites;
        private favoriteId;
        public dropDownToggle;
        constructor(public $http: ng.IHttpService, public $state: ng.ui.IStateService) {
            this.dropDownToggle = false;
            $http.get('api/alcohols/unsaved').then((res) => {
                this.drinks = res.data;
            })
            $http.get('api/favorites').then((res) => {
                this.favorites = res.data;
            })
        }

        public getDrinkId(id) {
            console.log(id);
            this.dropDownToggle = false;
            this.$http.get(`api/alcohols/${id}`).then((res) => {
                this.drinkId = res.data;
                console.log(this.drinkId);
            })
        }

        public addFav(drink) {
            this.$http.post('api/favorites', drink).then((res) => {
                this.favoriteId = res.data;
                console.log(this.favoriteId);
            })
        }

        
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
