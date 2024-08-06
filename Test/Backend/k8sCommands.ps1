docker build --no-cache -t testcommandsapi -f ./Test.Commands.Api/Dockerfile .

kubectl apply -f ./Test.Commands.Api/k8sDeployment.yml

kubectl apply -f ./Test.Commands.Api/k8sService.yml