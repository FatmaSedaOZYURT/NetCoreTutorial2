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
