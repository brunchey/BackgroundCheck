
backgroundCheckApp.controller('applicantsController',
    function ($scope, $location, $routeParams, ApplicantsService) {
        $scope.applicants = ApplicantsService.getApplicants();
        
        $scope.selectedApplicantId = $routeParams.applicantId;
});