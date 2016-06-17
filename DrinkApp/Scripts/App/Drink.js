//Angular functions
(function () {//Function for search view
    angular.module('SearchApp', []).controller('SearchController', function ($scope, $http) {
        //Global variabels
        $scope.selectedIndex = -1;
        $scope.DrinkInfo = "";
        $scope.list = "";
        $scope.query = "";
        //Post to get a list of all the drinks with the ingredents as subobjects
        $http.get('/api/drink/GetDrinks').then(function (response) {
            $scope.list = angular.fromJson(response.data);
        });
        //Find just the names then you type in the input button
        $scope.search = function (row) {
            var isOk = false;
            for (var i = 0; i < row.DRI.length; i++) {
                var NameToLower = row.Name.toLowerCase();
                isOk = ((NameToLower.indexOf($scope.query.toLowerCase() || '') !== -1));
                //|| DRINameToLower.indexOf($scope.query.toLowerCase() || '') !== -1));
                if (isOk) break;
            }
            return isOk;
        };
        //Get information on targeting drink
        $scope.getInfoAboutDrink = function (drink) {
            $scope.DrinkInfo = drink;
        }
        //Mark the taget drink
        $scope.selected = function (i) {
            $scope.selectedIndex = i;
        }

    });
})();
//Mix N Match Controller 
(function () {
    angular.module('MNMApp', []).controller('MNMController', function ($scope, $http) {
        //global variabels
        $scope.Lista = "";
        $scope.ingredientLista = [];
        $scope.drinkList = "";
        $scope.drinkIngredient = "";
        //Get list of all the ingredients
        $http.get('/api/ingredient/GetIngredients').then(function (response) {
            $scope.list = angular.fromJson(response.data);
        });
        //Add then chosen ingredeint to a array
        $scope.addToArray = function () {
            var exist = false;
            for (var i = 0; i < $scope.ingredientLista.length; i++) {
                if ($scope.ingredientLista[i].Name == $scope.Lista.Name)
                    return exist = true;
            }
            if (!exist)
                $scope.ingredientLista.push($scope.Lista);
        }
        //Remove from array
        $scope.removeItem = function (item) {
            remove($scope.ingredientLista, item)
        }

        function remove(arr, obj) {
            for (var i = arr.length - 1; i >= 0; i--) {
                if (arr[i].Name == obj.Name) {
                    arr.splice(i, 1);
                }
            }
        }

        //Get drink list from the chosen ingredients with a counter to show how the match was
        $scope.mixNmatch = function () {
            $http.post('/api/drink/PostDrinkIngrediensCounter', $scope.ingredientLista).then(function (response) {
                $scope.drinkList = angular.fromJson(response.data);
            });
        }
        //Show drinkinformation
        $scope.ShowDrinkInfo = function (x) {
            $http.post('/api/ingredient/PostDrinkId', x.DrinkID).then(function (response) {
                $scope.drinkIngredient = angular.fromJson(response.data);
                $scope.Procent = x.Procent;
            });
        }
        //hide info
        $scope.ClearInfo = function () {
            $scope.drinkIngredient = "";
        }
        //mark what info that was selected in the info window
        $scope.FindMatchIngredent = function (x) {
            for (var i = 0; i < $scope.ingredientLista.length; i++) {
                if ($scope.ingredientLista[i].Name == x.Name)
                    return "mark";
            }
            return;
        }

    });



})();

(function () {
    //Top drink controller
    angular.module('TDApp', []).controller('TDController', function ($scope, $http) {
        //Global variables
        $scope.drinkList = [];
        $scope.selectedDrink = "";
        //Get top 5 liked drinks
        $http.get('/api/drink/GetTopDrinks').then(function (response) {
            $scope.drinkList = angular.fromJson(response.data);
            $scope.PickDrink($scope.drinkList[0], 0);
        });
        //
        $scope.PickDrink = function (d, index) {
            $scope.selectedDrink = d;
            $scope.selectedIndex = index;
        }
    });
})();


(function () {
    //filter controller
    angular.module('FilterApp', []).controller('FilterController', function ($scope, $http) {
        //Global variables
        $scope.drinkList = [];
        $scope.tasteList = "";
        $scope.warning = false;
        $scope.drink = "";
        $scope.typeList = "";
        //Get Tase list
        $http.get('/api/drink/GetTaste').then(function (response) {
            $scope.tasteList = angular.fromJson(response.data);
        });
       //Get type list
        $http.get('/api/drink/GetTypes').then(function (response) {
            $scope.typeList = angular.fromJson(response.data);
        });

        //Post and get a random drink with the attrebutes you choose
        $scope.GetDrinkByFilter = function () {
            var data = [$scope.drinkTaste, $scope.drinkType]
            $http.post('/api/drink/PostDrinkFilter', data).then(function (response) {
                var resp = angular.fromJson(response.data);
                if (resp.DrinkID != 0) {
                    $scope.drink = resp;
                    $scope.warning = false;
                }
                else {
                    $scope.warning = true;
                    $scope.drink = "";
                }
                 
            })
        }


    });
})();