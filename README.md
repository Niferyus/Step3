
## Proje Hakkında
Step3, mikroservis mimarisi ile geliştirilmiş bir .NET tabanlı uygulamadır. GatewayAPI, Auth ve Product servislerini içerir. Her servis, kendi alanında ayrık olarak çalışır ve Docker ile kolayca dağıtılabilir.

## Kurulum

1. **Gereksinimler**
   - .NET 8 SDK
   - Docker & Docker Compose
   - Git

2. **Depoyu Klonlayın**
   ```powershell
   git clone https://github.com/Niferyus/Step3.git
   cd Step3
   ```

3. **Bağımlılıkları Yükleyin**
   - .NET bağımlılıkları otomatik olarak restore edilir.
   - Gerekirse, aşağıdaki komutla manuel olarak yükleyebilirsiniz:
     ```powershell
     dotnet restore
     ```

## Çalıştırma

### Geliştirme Ortamı

- Tüm servisleri Docker ile başlatmak için:
  ```powershell
  docker-compose up --build
  ```
- Sadece GatewayAPI’yi çalıştırmak için:
  ```powershell
  cd GatewayAPI
  dotnet run
  ```

## Design Pattern ve Kod Açıklamaları

Bu projede aşağıdaki yazılım tasarım desenleri kullanılmıştır:

### Dependency Injection (Bağımlılıkların Enjeksiyonu)
Servisler ve bileşenler, bağımlılıklarını doğrudan oluşturmak yerine dışarıdan alır. Bu sayede kodun test edilebilirliği ve esnekliği artar. .NET’in yerleşik DI konteyneri kullanılmıştır.

### Repository Pattern
Veri erişim katmanında, veri kaynaklarına erişimi soyutlamak için kullanılır. Böylece veri tabanı değişiklikleri uygulamanın geri kalanını etkilemez ve kodun sürdürülebilirliği sağlanır.

### Unit of Work
Birden fazla veri işleminin tek bir işlem olarak yönetilmesini sağlar. Transaction yönetimi kolaylaşır ve tutarlılık sağlanır.

### CQRS (Command Query Responsibility Segregation)
Okuma ve yazma işlemleri farklı modellerle ele alınır. Bu sayede performans ve ölçeklenebilirlik artar. Özellikle Application katmanında komutlar ve sorgular ayrı ayrı tanımlanmıştır.

Bu desenler, kodun okunabilirliğini, test edilebilirliğini ve bakımını kolaylaştırmak için tercih edilmiştir.
