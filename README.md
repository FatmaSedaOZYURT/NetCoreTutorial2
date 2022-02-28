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
      <th scope="col">Açıklamaası</th>
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
      <td>500 Internal Server error</td>
      <td>Server tarafında hata gerçekleştiği zaman buradan hata dönmelidir. </td>
    </tr>
  </tbody>
</table>
