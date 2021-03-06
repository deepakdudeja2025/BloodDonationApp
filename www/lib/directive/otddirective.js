﻿angular.module('Otd', ['OtdDirectives']);

/* Controllers */
function SearchForm($scope) {
    $scope.location = '';

    $scope.doSearch = function () {
        if ($scope.location === '') {
            alert('Directive did not update the location property in parent controller.');
        } else {
            alert('Yay. Location: ' + $scope.location);
        }
    };
}



/* Directives */
angular.module('OtdDirectives', []).
            directive('googlePlaces', function () {
                return {
                    restrict: 'E',
                    replace: true,
                    // transclude:true,
                    scope: { location: '=' },
                    template: "<label class='item item-input item-floating-label'><span class='input-label'>Enter Location Here</span><input id='google_places_ac' name='google_places_ac' type='text' />",
                    link: function ($scope, elm, attrs) {
                        var autocomplete = new google.maps.places.Autocomplete($("#google_places_ac")[0], {});
                        google.maps.event.addListener(autocomplete, 'place_changed', function () {
                            var place = autocomplete.getPlace();
                            $scope.location = place.geometry.location.lat() + ',' + place.geometry.location.lng();
                            $scope.$apply();
                        });
                    }
                }
            });