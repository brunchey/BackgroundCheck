backgroundCheckApp.service('ApplicantsService',
    function () {
        this.getApplicants = function () {
            return [
                {
                    Id: 0,
                    FirstName: 'Ben',
                    LastName: 'Runchey',
                    MiddleName: 'John'
                },
                {
                    Id: 1,
                    FirstName: 'Solomon',
                    LastName: 'Runchey',
                    MiddleName: 'Tumiso'
                },
                {
                    Id: 2,
                    FirstName: 'Samuel',
                    LastName: 'Runchey',
                    MiddleName: 'Dagim'
                },
                {
                    Id: 3,
                    FirstName: 'Jennifer',
                    LastName: 'Runchey',
                    MiddleName: 'Nicole'
                }
            ]
        };
    }
);