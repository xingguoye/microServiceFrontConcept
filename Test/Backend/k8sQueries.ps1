docker build --no-cache -t testqueriesapi -f ./Test.Queries.Api/Dockerfile .

kubectl apply -f ./Test.Queries.Api/k8sDeployment.yml

kubectl apply -f ./Test.Queries.Api/k8sService.yml

kubectl apply -f ./Test.Queries.Api/k8sAutoscale.yml