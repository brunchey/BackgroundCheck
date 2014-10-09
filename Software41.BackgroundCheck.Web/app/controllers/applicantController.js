
backgroundCheckApp.controller('applicantsController',
    function ($scope, applicantService) {
        $scope.applicants = {}; 

        //todo - add search filter here for results

        applicantService.getApplicants()
            .success(function (data) {
                $scope.applicants = data;
            })
            .error(function (error) {
                $scope.isError = error;
            });

        
    });

backgroundCheckApp.controller('applicantController',
    function ($scope, $routeParams, $location, applicantService) {
        
        $scope.id = $routeParams.Id;
        $scope.applicant;
        
        $scope.saveApplicant = function () {

            if ($scope.id == '') {
                applicantService.create($scope.applicant);
            }
            else {
                applicantService.update($scope.applicant);
            }

            $location.path('/');
        };

        if ($scope.id != ''){
            applicantService.getApplicantDetails($scope.id)
                .success(function (data) {
                    $scope.applicant = data;
                })
                .error(function (error) {
                    $scope.isError = error;
                });
        };

    });
