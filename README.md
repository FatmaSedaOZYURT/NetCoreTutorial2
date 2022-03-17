# NetCoreTutorial2
 
<h1>Doğru Api/Endpoint Yapısı</h1>
<p>Senaryoya uygun istek tipleri olmalıdır. Diğer türlü çoğunu post yapmak client'ı yoracaktır.</p>
<p>Elbette, <b>Yanlış</b> olarak gösterilen alandakiler de kullanılabilir fakat dışarıya açılan istekler <b>Doğru</b> kullanım alanında belirtildiği gibi olmalıdır ve genel olarak çoğul olmasına dikkat etmemiz gerekmektedir <b>(Best Practices gereği)</b>.</p>
<table class="table">
  <thead>
    <tr>
      <th scope="col">#</th>
      <th scope="col">Metot</th>
      <th scope="col">Doğru</th>
      <th scope="col">Yanlış</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <th scope="row">1</th>
      <td>Get</td>
      <td>.../api/products</td>
      <td>.../api/getproduct</td>
    </tr>
    <tr>
      <th scope="row">2</th>
      <td>Get</td>
      <td>.../api/products/10</td>
      <td>.../api/getproductbyId</td>
    </tr>
    <tr>
      <th scope="row">3</th>
      <td>Post</td>
      <td>.../api/products</td>
      <td>.../api/saveproduct</td>
    </tr>
    <tr>
      <th scope="row">4</th>
      <td>Put</td>
      <td>.../api/products</td>
      <td>.../api/updateproduct</td>
    </tr>
    <tr>
      <th scope="row">5</th>
      <td>Delete</td>
      <td>.../api/products/2</td>
      <td>.../api/deleteproduct</td>
    </tr>
  </tbody>
</table>

<h1>Durum Kodları</h1>

<table class="table">
  <thead>
    <tr>
      <th scope="col">#</th>
      <th scope="col">Kod</th>
      <th scope="col">Açıklaması</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <th scope="row">1</th>
      <td>200 Ok</td>
      <td>İşlem Başarılıysa bu kod dönmelidir.</td>
    </tr>
    <tr>
      <th scope="row">2</th>
      <td>201 Created</td>
      <td>Yeni kayıtlarda burası dönmelidir.</td>
    </tr>
    <tr>
      <th scope="row">3</th>
      <td>204 NoContent</td>
      <td>İstek başarılı fakat cevap dönmediğini belirtir. Bu durum kodunu Put (güncellemelerde) ve Delete (silme) isteklerinde kullanmamız gerekmektedir.</td>
    </tr>
    <tr>
      <th scope="row">4</th>
      <td>400 BadRequest</td>
      <td>Eksik istek gibi durumlarda bu kod dönmelidir.</td>
    </tr>
    <tr>
      <th scope="row">5</th>
      <td>401 Unauthorized</td>
      <td>Server tarafında herhangi bir güvenlik kontrolünü sağlamaıyorsa (yetki kısıtlaması), (token vs.) bu kod dönmelidir. </td>
    </tr>
   <tr>
      <th scope="row">6</th>
      <td>403 Forbid</td>
      <td>Token doğru fakat istek atılan endpoint'e yetkisi yoksa, bu hata kodu dönmelidir.</td>
    </tr>
   <tr>
      <th scope="row">6</th>
      <td>404 NotFound</td>
      <td>İşlem yapılmak istenen veri VT de yoksa, bu hata kodu dönmelidir.</td>
    </tr>
   <tr>
      <th scope="row">7</th>
      <td>500 Internal Server Error</td>
      <td>Server tarafında hata gerçekleştiği zaman bu hata kodu dönmelidir. </td>
    </tr>
  </tbody>
</table>

<h1>Best Practices</h1>
<ul>
 <li>Uygulamayı küçük parçalara bölün.</li>
 <li>Action metotlarında business kodu olmamalıdır.</li>
 <li>Action metotlarının içinde try cache blokları olmamalı. <p>⭐ Hatalar tek bir yerden kontrol edilmelidir.</p></li>
 <li>Action metotlar içinde kod tekrarından kaçının. <p>⭐ Örnek: ValidationFilter attribute'u kullunmak, id ile gtirme işlemi action metodunda birden fazla yerde çağırılıyorsa, ServiceFilter attribute'u yazılabilir.</p></li>
 <li>Action metotlarına mode sınıflarımızı dönmemeiz gerekmektedir. DTO sınıfları dönülmelidir. <p>🌟 Benim görüşüme göre; belki de şu şekilde değerlendirmemiz gerekmekte, eğer model sınıfını geri döndüğümüzü varsayarsak, dışarıya vt'deki kolon isimlerini geri dönmüş olacağız. Böylelikle, bir güvenlik zafiyeti oluşturmuş olacağız. Bunu önlemek adına DTO snıfları kullanmak daha mantıklı olacaktır. <p></li>
</ul>

<h1>N-Layer Proje Yapısı</h1>
En az 3 katmandan oluşmalıdır.
<ul>
 <li>Core Katmanı <p>Projenin çekirdeğini oluşturmaktadır. Model(Entity), DTO, Repository Interface, Service Interface, UnitOfWork Interfaces</p></li>
 <li>Repository Katmanı <p>Migration, Seeds, Repository Implementation, UnitOfWork Implementation</p></li>
 <li>Caching</li>
 <li>Service Katmanı <p>Bussiness kodları olmalıdır. Mapping, Service Implementation, Validations, Exceptions</p></li>
 <li>API Katmanı</li>
 <li>Web Katmanı</li>
</ul>

<h1>New Hosting Model in Net 6.0</h1>
Yeni .Net 6 da yalnızca birkaç satır kod ve bir dosya gereklidir model hosting i yapabilmek için. 6.0 da migration uygulaması yeni küçük hosting modelini kullanmaz. 
<p>Minimal Hosting Model:</p>
<ul>
 <li>Bir uygulama oluşturmak için dosya ve kod satırlarının sayısını önemli ölçüde azaltır.</li>
 <li>Startup.cs ve Program.cs dosyalarını tek dosyada, Program.cs de birleştirir.</li>
 <li>Bir uygulama için gereken kodu en aza indirmek için üst düzey ifadeleri kullanır.</li>
 <li>Gereken kullanım ifadesi satırlarının sayısını ortadan kaldırmak veya en aza indirmek için genel kullanma yönergelerini kullanır.</li>
</ul>
ConfigureServices, WebApplication.Services olarak değiştirildi.
builder.Build(), değişken uygulamaya yapılandırılmış bir WebApplication döndürür. Configure, uygulamayı kullanarak aynı hizmetlere yapılan yapılandırma çağrılarıyla değiştirilir.
<p>🔔 Web App template inde de bir kaç değişiklik olmuştur.</p>
<p> - Index.cshtml ve Privacy.cshtml using statement ı kaldırıldı.</p>
<p> - Error.cshtml de RequestId nullable yapıldı.</p>
<p> - appsettings.json ve appsettings.Development.json dan "Microsoft.Hosting.Lifetime": "Information" satır kaldrıldı.</p>

<h2>Dikkatli olunması gerekenler</h2>
<p>⭐ Program.cs,  Startup sınıfının yaşama süresini ve somutlaştırmasını kontrol eder.</p>
<p>⭐ Configure yöntemine eklenen tüm ek hizmetlerin Program sınıfı tarafından manuel olarak çözülmesi gerekir.</p>

<h1>IUnitOfWork Pattern</h1>
<p>VT ye yapılacak işlemleri toplu bir şekilde tek bir transaction üzerinden yönetmemizi sağlar.</p>
<p>SaveChanges() diyene kadar ef bunu memory de tutar.</p>
Bu metodu kontrol altına alınması lazım. Bunu sağlayacak olan IUnitOfWork sağlayacaktır.
Eğer Bu pattern olmasaydı; veri kaybı yapılabilirdi. 
<p>Yapılan herhangi bir hatada, tüm işlemleri geri almayı, transaction yapmayı ef core yapacaktır.</p>

<h2>☄️ DTO Classes</h2>
<p>DTO sınıfları, Core katmanında yazılmalıdır. Çünkü, Core katmanı tüm katmalarda var ve DTO'lar da tüm katmanlarda kullanılmak istenebilir. </p>

<h1>Özel Validasyon Oluşturma</h1>
Bu projede Fluent Validation kullanılmıştır.
Önce, bu validasyona özel sınıfımızı oluşturduk.
<br>
<a href="https://github.com/FatmaSedaOZYURT/NetCoreTutorial2/blob/main/NLayer.Service/Validations/ProductDtoValidator.cs">Koda Git</a> 
<br>
<br>
 Sonrasında bunu hata mesajlarını kendi özel cevabımızda dönmemiz gerekecektir.
 <br>
 <a href="https://github.com/FatmaSedaOZYURT/NetCoreTutorial2/blob/main/NLayer.API/Filters/ValidateFilterAttribute.cs">Koda Git</a>
 <br>
  
 Yazmış olduğumuz bu özel cevabı Core'a bildirmemiz gerekiyor.
 Program.cs in içine;
  <code>
   //Validator ü ekliyoruz
builder.Services.AddControllers(options => options.Filters.Add(new ValidateFilterAttribute())).AddFluentValidation(x=>x.RegisterValidatorsFromAssemblyContaining<ProductDtoValidator>());
//Filter için kendi özel sınıfımızı yazdık ve bunu bildiirmemiz gerekiyor servisimize eğer bildirmezsek fluent in validation'ını kullanacaktır.
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});
  </code>

 <p>⭐ Eğer bir filter'ınız constructor'ında parametre istiyorsa, bunu Program.cs'de belirtmemiz gerekir.</p>
 <code>builder.Services.AddScoped(typeof(NotFoundFilter<>));</code>
  <p>Bu filter'ı kullanabilmemiz için attribute şeklinde yazarken, ServiceFilter kullanılmalıdır. Çünkü bizim filter'imiz generic bir yapı ve bir tip istemekte.</p>
  <p>Örnek: </p>
  <code>[ServiceFilter(typeof(NotFoundFilter<Product>))]</code>
