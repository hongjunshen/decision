//(function () {
//    'use strict';

(function () {
    'use strict';

    angular
        .module('app')
        .controller('ApplicantCtrl', ApplicantCtrl);

    function ApplicantCtrl(applicantService) {
        var vm = this;

        //used for setting max value of DOB
        vm.currentDate = new Date();

        //retrieve all applicants
        vm.getApplicants = function () {
            applicantService.getApplicants()
                .then(function (results) {
                    vm.applicants = results;
                },
                function (error) {
                    vm.applicants = null;
                });
        }

        vm.getApplicants();

        //save one applicant to database
        vm.save = function () {
            var obj = {
                firstName: vm.firstName,
                lastName: vm.lastName,
                dob: vm.dob,
                gpa: vm.gpa
            };
            applicantService.save(obj).then(function (response) {
                vm.getApplicants();
                vm.reset();
            }, function (data) {
                vm.error = "An error has occured while adding applicants! " + data;
            });
        }

        //reset form after adding a new record to database
        vm.reset = function () {
            vm.firstName = '';
            vm.lastName = '';
            vm.dob = null;
            vm.gpa = null;
        }
    }
})();


