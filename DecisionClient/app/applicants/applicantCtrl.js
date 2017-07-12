(function () {
    'use strict';

    angular
        .module('app')
        .controller('ApplicantCtrl', ApplicantCtrl);

    function ApplicantCtrl($http) {
        var vm = this;

        vm.currentDate = new Date();
        vm.title = 'hi';
      
        vm.getApplicants = function () {
            $http.get('http://localhost:64239/api/applicant/')
                .then(function (response) {
                    vm.applicants = response.data;
                    console.log(vm.applicants);
                });
        }

        vm.getApplicants();

        vm.save = function () {
            var obj = {
                firstName: vm.firstName,
                lastName: vm.lastName,
                dob: vm.dob,
                gpa: vm.gpa
            };
            $http.post('http://localhost:64239/api/applicant/', obj).then(function (response) {
                vm.getApplicants();
                vm.reset();
            }, function (data) {
                vm.error = "An error has occured while adding applicants! " + data.ExceptionMessage;
            });
        }

        vm.reset = function () {
            vm.firstName = '';
            vm.lastName = '';
            vm.dob = null;
            vm.gpa = null;
        }
    }
})();