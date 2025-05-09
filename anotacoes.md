## Kompose

O **Kompose** é uma ferramenta que converte arquivos docker-compose.yml em manifestos Kubernetes (`Deployment`, `Service`, `PersistentVolume`, etc.). Ele é útil para migrar aplicações baseadas em Docker Compose para Kubernetes de forma rápida e automatizada.

---

### Principais Características do Kompose:
1. **Conversão Automática**:
   - Converte serviços definidos em docker-compose.yml para recursos Kubernetes, como `Deployment`, `Service`, `ConfigMap`, etc.

2. **Facilidade de Migração**:
   - Ideal para desenvolvedores que já usam Docker Compose e desejam migrar para Kubernetes sem criar os manifestos manualmente.

3. **Suporte a Recursos do Docker Compose**:
   - Suporta configurações como volumes, redes, variáveis de ambiente e dependências.

4. **Flexibilidade**:
   - Permite personalizar a saída, gerando apenas os recursos necessários (por exemplo, apenas `Deployment` ou `Service`).

---

### Como Funciona:
1. **Entrada**:
   - Um arquivo docker-compose.yml que define os serviços, volumes e redes.

2. **Saída**:
   - Arquivos YAML para Kubernetes, como:
     - `*deployment.yaml`: Gerencia os pods.
     - `*service.yaml`: Exposição dos pods.
     - `*persistentvolume.yaml`: Gerencia volumes persistentes.

3. **Comando Principal**:
   - Para converter:
     ```bash
     kompose convert
     ```

---

### Exemplo de Uso:
#### Arquivo docker-compose.yml:
```yaml
services:
  web:
    image: nginx
    ports:
      - "8080:80"
```

#### Conversão com Kompose:
```bash
kompose convert
```

#### Saída Gerada:
- `web-deployment.yaml`:
  ```yaml
  apiVersion: apps/v1
  kind: Deployment
  metadata:
    name: web
  spec:
    replicas: 1
    selector:
      matchLabels:
        app: web
    template:
      metadata:
        labels:
          app: web
      spec:
        containers:
        - name: web
          image: nginx
          ports:
          - containerPort: 80
  ```

- `web-service.yaml`:
  ```yaml
  apiVersion: v1
  kind: Service
  metadata:
    name: web
  spec:
    selector:
      app: web
    ports:
    - protocol: TCP
      port: 8080
      targetPort: 80
    type: ClusterIP
  ```

### Quando Usar o Kompose:
- Para migrar aplicações existentes baseadas em Docker Compose para Kubernetes.
- Para criar rapidamente manifestos Kubernetes a partir de configurações Docker Compose.

O Kompose é uma ferramenta prática para quem está começando com Kubernetes e já utiliza Docker Compose.

---

Os arquivos `*deployment.yaml` e `*service.yaml` gerados pelo **Kompose** têm propósitos diferentes no Kubernetes. Aqui está a explicação das diferenças:

---

### 1. **Deployment (`*deployment.yaml`)**
O arquivo `*deployment.yaml` é responsável por gerenciar a implantação (deployment) de um ou mais **pods** no cluster Kubernetes.

#### Principais Características:
- **Gerencia Pods**:
  - Define como os pods devem ser criados e gerenciados.
  - Garante que o número desejado de réplicas (pods) esteja sempre em execução.
- **Escalabilidade**:
  - Permite escalar o número de réplicas ajustando o campo `spec.replicas`.
- **Atualizações**:
  - Suporta atualizações contínuas (rolling updates) para implantar novas versões da aplicação sem downtime.
- **Estrutura Geral**:
  ```yaml
  apiVersion: apps/v1
  kind: Deployment
  metadata:
    name: <nome-do-deployment>
  spec:
    replicas: <número-de-réplicas>
    selector:
      matchLabels:
        app: <nome-do-app>
    template:
      metadata:
        labels:
          app: <nome-do-app>
      spec:
        containers:
          - name: <nome-do-container>
            image: <imagem-docker>
            ports:
              - containerPort: <porta>
  ```

---

### 2. **Service (`*service.yaml`)**
O arquivo `*service.yaml` é responsável por expor os pods gerenciados pelo Deployment para que eles possam ser acessados dentro ou fora do cluster.

#### Principais Características:
- **Exposição de Pods**:
  - Cria um ponto de acesso estável para os pods, mesmo que os pods sejam recriados ou escalados.
- **Tipos de Serviço**:
  - **ClusterIP** (padrão): Exposição interna no cluster.
  - **NodePort**: Exposição externa em uma porta específica do nó.
  - **LoadBalancer**: Exposição externa com balanceamento de carga.
- **Estrutura Geral**:
  ```yaml
  apiVersion: v1
  kind: Service
  metadata:
    name: <nome-do-serviço>
  spec:
    selector:
      app: <nome-do-app>
    ports:
      - protocol: TCP
        port: <porta-exposta>
        targetPort: <porta-do-container>
    type: <tipo-do-serviço>
  ```

---

### Diferenças Principais:
| **Aspecto**         | **Deployment (`*deployment.yaml`)**                          | **Service (`*service.yaml`)**                          |
|----------------------|-------------------------------------------------------------|-------------------------------------------------------|
| **Propósito**        | Gerenciar a criação e o ciclo de vida dos pods.             | Expor os pods para acesso interno ou externo.         |
| **Escalabilidade**   | Define o número de réplicas (pods) a serem executadas.       | Não gerencia réplicas, apenas expõe os pods existentes. |
| **Atualizações**     | Suporta atualizações contínuas (rolling updates).            | Não realiza atualizações, apenas roteia o tráfego.    |
| **Exposição**        | Não expõe os pods diretamente.                              | Cria um ponto de acesso estável para os pods.         |
| **Campos Importantes** | `spec.replicas`, `spec.template`, `spec.selector`.         | `spec.selector`, `spec.ports`, `spec.type`.           |

---

### Exemplo Gerado pelo Kompose:
#### Arquivo sqlexpress-deployment.yaml:
- Gerencia o pod do SQL Server.
- Define 1 réplica do pod.
- Monta um volume persistente para armazenar os dados do banco.

#### Arquivo sqlexpress-service.yaml (não visível, mas esperado):
- Exporia o pod do SQL Server.
- Configuraria a porta 1433 para acesso interno ou externo.
- Usaria um `selector` para associar o serviço ao pod gerenciado pelo Deployment.

---

### Conclusão:
- O **Deployment** é responsável por gerenciar os pods e garantir que eles estejam sempre em execução.
- O **Service** é responsável por expor os pods para que possam ser acessados por outros serviços ou usuários.

Ambos são complementares e geralmente usados juntos para implantar e expor aplicações no Kubernetes.


# Acessando os serviços
Sim, para acessar um serviço no Minikube a partir da sua máquina local, você precisa garantir que as portas estão mapeadas corretamente. Aqui estão as opções para acessar o serviço:

---

### Opção 1: Usar `NodePort`
Se o serviço estiver configurado como `NodePort`, você pode acessar diretamente o serviço usando o IP do Minikube e a porta configurada no `nodePort`.

1. **Verificar o Serviço**:
   Liste os serviços para confirmar o tipo e as portas:
   ```bash
   kubectl get services
   ```

   Exemplo de saída:
   ```plaintext
   NAME                           TYPE       CLUSTER-IP       EXTERNAL-IP   PORT(S)          AGE
   hackathon-schedule-service     NodePort   10.101.17.238    <none>        8080:31300/TCP   5m
   ```

   - **`8080`**: Porta interna do container.
   - **`31300`**: Porta externa configurada no `nodePort`.

2. **Obter o IP do Minikube**:
   Use o comando abaixo para obter o IP do Minikube:
   ```bash
   minikube ip
   ```

   Exemplo de saída:
   ```plaintext
   192.168.49.2
   ```

3. **Acessar o Serviço**:
   Use o IP do Minikube e a porta configurada no `nodePort` para acessar o serviço. Por exemplo, para acessar o Swagger:
   ```plaintext
   http://192.168.49.2:31300/swagger
   ```

---

### Opção 2: Usar `kubectl port-forward`
Se o serviço estiver configurado como `ClusterIP` ou você preferir não expor o serviço externamente, use o comando `kubectl port-forward` para redirecionar a porta do serviço para sua máquina local.

1. **Executar o Port Forwarding**:
   ```bash
   kubectl port-forward service/hackathon-schedule-service 8080:8080
   ```

   Isso redirecionará a porta `8080` do serviço `hackathon-schedule-service` para a porta `8080` na sua máquina local.

2. **Acessar o Serviço**:
   Agora você pode acessar o serviço localmente usando:
   ```plaintext
   http://localhost:8080/swagger
   ```

---

### Opção 3: Usar `minikube service`
Se você estiver usando Minikube, pode usar o comando `minikube service` para abrir o serviço diretamente no navegador.

1. **Abrir o Serviço**:
   ```bash
   minikube service hackathon-schedule-service
   ```

   Isso abrirá o serviço no navegador usando o IP e a porta configurados.

2. **Obter a URL do Serviço**:
   Se você quiser apenas a URL, use:
   ```bash
   minikube service hackathon-schedule-service --url
   ```

---

### Passo Adicional: Verificar Configuração do Serviço
Certifique-se de que o serviço está configurado corretamente no arquivo YAML. Por exemplo, para `NodePort`:

```yaml
apiVersion: v1
kind: Service
metadata:
  name: hackathon-schedule-service
spec:
  type: NodePort
  ports:
    - port: 8080
      targetPort: 8080
      nodePort: 31300
  selector:
    io.kompose.service: hackathon-schedule-service
```

Reaplique o serviço se necessário:
```bash
kubectl apply -f hackathon-schedule-service.yaml
```

---

### Conclusão
- Use **`NodePort`** para acesso direto via IP do Minikube.
- Use **`kubectl port-forward`** para redirecionar a porta para sua máquina local.
- Use **`minikube service`** para abrir o serviço diretamente no navegador.

Escolha a opção que melhor se adapta ao seu caso. Se o problema persistir, compartilhe os logs ou mensagens de erro para mais ajuda.