PrevisaoApp.controller('cidadeController', ['$scope', '$http', '$window', 'previsaoService', function ($scope, $http, $window, previsaoService) {

    $scope.initCidade = function () {

        $scope.cidades = {};
        $scope.loading = false;
        getCidades($scope, previsaoService);

    }

    $scope.redirecionarFormCadastro = function () {
        window.location.pathname = '/Home/CadastroCidade'
    }

    $scope.redirecionarPrevisao = function (idAPI) {
        window.location.href = "/Home/Previsao?idAPI=" + idAPI;
    }

    $scope.cadastrarCidade = function () {

        if (typeof ($scope.Cidade) == "undefined" || $scope.Cidade == "") {
            $window.alert("Informe o nome da cidade.");
            return;
        }

        var data = {
            nomeCidade: $scope.Cidade
        };


        return $http.post('/CadastroCidade/CadastrarCidade/', data).then(function (result) {

            var retorno = JSON.parse(result.data);

            if (!retorno.Sucesso) {
                $window.alert(retorno.Mensagem);
            }
            else {
                $window.alert('Cadastro realizado com sucesso!');
                window.location.pathname = 'Home/Index'
            }
        });
    }

}]);

function getCidades($scope, previsaoService) {

    $scope.loading = true;
    previsaoService.request('/CadastroCidade/ObterCidades', 'Get', null).then(function (result) {

        if (result != null) {
            $scope.cidades = result.Lista;
            console.log(result.Lista);
        }

        $scope.loading = false;

    }, function (data) {
        console.log = "Ocorreu um erro ao carregar a lista de cidades.";
        $scope.loading = false;
    })
}




