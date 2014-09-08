
backgroundCheckApp.controller('applicantsController',
    function ($scope, $location, $routeParams, $http, ApplicantsService) {
        $scope.applicants = {}; // ApplicantsService.getApplicants();
        
        $http.get('../api/applicant')
            .success(function (data) {
                $scope.applicants = data;
            })
            .error(function (error) {
                $scope.isError = error;
            });

        $scope.selectedApplicantId = $routeParams.applicantId;
});