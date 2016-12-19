namespace AlcoholApp.Controllers {

    export class HomeController {
        constructor(public $http: ng.IHttpService, public $state: ng.ui.IStateService, public $uibModal: ng.ui.bootstrap.IModalService, public ModalService: AlcoholApp.Services.ModalService) { }


    }


    export class ModalController {
        public loginUser;

        constructor(public $http: ng.IHttpService, public $state: ng.ui.IStateService, public $uibModalInstance: ng.ui.bootstrap.IModalServiceInstance) { }
        
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
        public alcoholInfo;
        public alcohols;
        public reason;
        public volume = null;
        public glasses;
        public fGlasses;
       

        constructor(public $http: ng.IHttpService, public $state: ng.ui.IStateService) {
            this.dropDownToggle = false;
            $http.get('api/alcohols/unsaved').then((res) => {
                this.drinks = res.data;
            })           
            $http.get('api/glasses').then((res) => {
                this.favorites = res.data;
            })
            $http.get('api/glasses/falseGlasses').then((res) => {
                this.fGlasses = res.data;
            })
        }

        public addGlass() {
            this.$http.post(`api/glasses/newGlasses/${this.volume}`, this.alcoholInfo).then((res) => {
                this.$state.reload();
            })
        }

        public selectAlcohol(alcoholId) {
            this.$http.get(`api/alcohols/${alcoholId}`).then((res) => {
                this.alcoholInfo = res.data;
            })
        }

        public addFav(drink) {
            this.$http.post('api/glasses', drink).then((res) => {
                this.$state.reload();
            }).catch((reason) => {
                this.reason = reason.data;
                alert(this.reason);
            })          
    }

        public check() {
            if (this.volume == null) {
                return true;
            } else {
                return false;
            }
        }

        public deleteFav(id) {
            this.$http.delete(`api/glasses/${id}`).then((res) => {
                this.$state.reload();
            })
        }


        public search(text) {
            if (text == "") {
                this.dropDownToggle = false;
            } else {
                this.dropDownToggle = true;
            }
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
