docker build --no-cache -t testconsumer -f ./Test.Consumer/Dockerfile .

kubectl apply -f ./Test.Consumer/k8sDeployment.yml