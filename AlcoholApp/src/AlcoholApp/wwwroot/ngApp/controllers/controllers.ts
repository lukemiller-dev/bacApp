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

    /**
     * MAIN ACCOUNT CONTROLLER
     */

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
        public tGlasses;
        public appUsers;
        public weight;
        public bac;
        public bacBool;
        public maxVal;
        public icon;
        public defIcon = false;
        public defDrink = false;
        public skull;
        public falling;
        public merked;
        public blackout;
        public firstValB;
        public lastGlass;
        public noGlassShow = false;
        public firstGlassShow = false;
        public lastGlassShow = false;



        constructor(public $http: ng.IHttpService, public $state: ng.ui.IStateService, public $scope) {
            this.dropDownToggle = false;

            $http.get('api/alcohols/unsaved').then((res) => {
                this.drinks = res.data;
            })
            $http.get('api/glasses').then((res) => {
                this.favorites = res.data;
            })
            $http.get('api/glasses/falseGlasses').then((res) => {
                this.fGlasses = res.data;
            }).then((res) => {
                this.lastGlass = this.fGlasses[0];

             

                if (this.fGlasses.length == 0) {
                    this.noGlassShow = true;
                } else {
                    this.lastGlassShow = true;
                }

                for (var i = 0; i < this.lastGlass.alcohol.volumes.length; i++) {

                    if (this.lastGlass.volume == parseFloat(this.lastGlass.alcohol.volumes[i].split(' ')[0])) {
                        this.volume = this.lastGlass.alcohol.volumes[i];

                    }

                }
             })

            $http.get('api/glasses/trueGlasses').then((res) => {
                this.tGlasses = res.data;
            })

            $http.get('api/appUsers/BAC').then((res) => {
                this.bac = res.data;
            })
            this.maxVal = 0.2;

        }



        public addGlass() {
            
            this.$http.post(`api/glasses/newGlasses/${this.volume}`, this.alcoholInfo).then((res) => {
                this.$state.reload();
                });
        }

        public addLastGlass() {
            if (isNaN(this.volume)) {
                this.$http.post(`api/glasses/newGlasses/${this.volume}`, this.lastGlass.alcohol).then((res) => {
                    this.$state.reload();
                })
                }else {
                var splitVol = this.volume.split(' ');
                console.log(splitVol[0]);
                console.log(this.volume);
                this.$http.post(`api/glasses/newGlasses/${parseFloat(splitVol[0])}`, this.lastGlass.alcohol).then((res) => {                  
                    this.$state.reload();
                    
                })
            }
        }
    

        public selectAlcohol(alcoholId) {
            this.$http.get(`api/alcohols/${alcoholId}`).then((res) => {
                this.alcoholInfo = res.data;
                this.defIcon = true;
                this.defDrink = true;
                this.noGlassShow = false;
                this.firstGlassShow = true;
                //this.firstValB = this.alcoholInfo.volumes[0];
                //console.log(this.firstValB);
                this.volume = this.alcoholInfo.volumes[0];
                this.lastGlassShow = false;
            });

            this.firstValB = this.alcoholInfo.volumes[0];
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
            if (this.defIcon && this.defDrink) {
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

        public setWeight() {
            this.$http.put(`api/appUsers/weight`, this.weight).then((res) => {
                console.log(this.weight);
                this.$state.reload();

            })
        }

        public checkBAC() {
            if (this.bac > 0.07) {
                return this.bacBool = true;
            }
            else {
                return this.bacBool = false;
            }
        }

        

        public showSkull() {
            if (this.bac > .19) {
                return this.skull = true;
            } else {
                return this.skull = false;
            }
        }

        public showFalling() {
            if (this.bac > .11) {
                return this.falling = true;
            } else {
                return this.falling = false;
            }
        }

        public showMerked() {
            if (this.bac > .14) {
                return this.merked = true;
            } else {
                return this.merked = false;
            }
        }

        public showBlackout() {
            if (this.bac > .17) {
                return this.blackout = true;
            } else {
                return this.blackout = false;
            }
        }


        public deleteFalseG(id) {
            this.$http.delete(`api/glasses/false/${id}`).then((res) => {
                this.$state.reload();
            })
        }

        public deleteAllFalseGs() {
            this.$http.delete('api/glasses/allFalse').then((res) => {
                this.$state.reload();
            })
        }

        
        }


    






    export class AlcoholController {
        public alcohols;
        public bac;
        public maxVal;
        public bacBool;
        constructor(public $http: ng.IHttpService, public $state: ng.ui.IStateService, public $scope: ng.IScope) {
            $http.get('api/alcohols').then((res) => {
                this.alcohols = res.data;
            });
            $http.get('api/appUsers/BAC').then((res) => {
                this.bac = res.data;
            });
            this.maxVal = 0.2;
        }

        public addAlcohol(alcohol) {
            this.$http.post('api/alcohols', alcohol).then((res) => {
                this.$state.reload();
            })
        }
        public deleteAlco(id) {
            this.$http.delete(`api/Alcohols/${id}`).then((res) => {
                this.$state.reload();
            });
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
    export class EditController {
        public alcoholses;
        constructor(public $http: ng.IHttpService, public $stateParams:
            ng.ui.IStateParamsService, public $state:ng.ui.IStateService) {
            $http.get(`/api/Alcohols/${$stateParams["id"]}`).then((res) => {
                this.alcoholses = res.data;
            });
        }
        public editAlcohol() {
            this.$http.put(`/api/Alcohols/${this.$stateParams["id"]}`, this.alcoholses).then((res) => {
                this.$state.go('addalcohol');
            });
        }

    }

}


