(function () {
    angular
        .module('app')
        .factory('applicantService', applicantService);

    function applicantService($http) {
        // config
        var baseAddress = "http://localhost:64239/api/";

        // public api
        var service = {
            getApplicants: getApplicants,
            save: save
        };

        return service;

        //retrieve all applicants
        function getApplicants() {
            return $http.get(baseAddress + 'applicant/')
                .then(function (response) {
                    console.log(response.data);
                    return response.data;
                });
        }
        
        //save one applicant
        function save(applicant) {
            return $http.post(baseAddress + 'applicant/', applicant).then(function (response) {
                return response.data;
            }, function (data) {
                return  data.ExceptionMessage;
            });
        }
    }
})();