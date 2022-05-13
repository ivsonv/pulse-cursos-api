using Admin.Domain.Models.DTO.Helpers;
using System.Net;
using System.Net.Http.Headers;

namespace Admin.Domain.Helpers
{
    public class RequestHttp : Interface.Helpers.IRequestHttp
    {
        public async Task<HttpRs> Get(HttpDto dto)
        {
            var _res = new HttpRs();
            try
            {
                using (var _http = new HttpClient())
                {
                    // headers
                    if (dto.Headers.IsNotEmpty())
                        dto.Headers.ForEach(x => _http.DefaultRequestHeaders.Add(x.name, x.value));

                    // requisition
                    var response = await _http.GetAsync(dto.Url);

                    // return
                    if (response.IsSuccessStatusCode)
                    {
                        _res.Data = await response.Content.ReadAsStringAsync();
                        _res.HasSuccess = true;
                    }
                    else
                        response.EnsureSuccessStatusCode();

                    return _res;
                }
            }
            catch (HttpRequestException e)
            {
                _res.Data = e.Message;
            }
            catch (WebException ex)
            {
                _res.Data = ex.Message;
                if (ex.Response != null)
                {
                    using (var streamReader = new StreamReader(ex.Response.GetResponseStream()))
                    {
                        string msg = streamReader.ReadToEnd();
                        if (msg.IsNotEmpty())
                            _res.Data = msg;
                    }
                }
            }
            catch { throw; }
            return _res;
        }
        public async Task<HttpRs> Get(string url)
        {
            return await Get(new HttpDto() { Url = url });
        }

        public async Task<HttpRs> Post(HttpDto dto)
        {
            var _res = new HttpRs();
            try
            {
                using (var _http = new HttpClient())
                {
                    _http.DefaultRequestHeaders.Clear();
                    _http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    // headers
                    if (dto.Headers.IsNotEmpty())
                        dto.Headers.ForEach(x =>
                        {
                            switch (x.name)
                            {
                                case "Authorization":
                                    _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(x.scheme, x.value);
                                    break;

                                case "Content-Type":
                                    _http.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", x.value);
                                    break;

                                default:
                                    _http.DefaultRequestHeaders.Add(x.name, x.value);
                                    break;
                            }
                        });

                    // response
                    HttpResponseMessage response = null;

                    if (!(dto.Payload is null))
                    {
                        // payload
                        var content = new StringContent(dto.Payload.Serialize(), dto.Encoding, "application/json");

                        // requisition
                        response = await _http.PostAsync(dto.Url, content);
                    }

                    // payload formURL
                    if (!(dto.PayloadFormUrlEncode is null))
                    {
                        response = await _http.PostAsync(dto.Url, dto.PayloadFormUrlEncode);
                    }

                    // return
                    if (response.IsSuccessStatusCode)
                    {
                        _res.Data = await response.Content.ReadAsStringAsync();
                        _res.HasSuccess = true;
                    }
                    else
                        response.EnsureSuccessStatusCode();
                }
                return _res;
            }
            catch (HttpRequestException e)
            {
                _res.Data = e.Message;
            }
            catch (WebException ex)
            {
                _res.Data = ex.Message;
                if (ex.Response != null)
                {
                    using (var streamReader = new StreamReader(ex.Response.GetResponseStream()))
                    {
                        string msg = streamReader.ReadToEnd();
                        if (msg.IsNotEmpty()) _res.Data = msg;
                    }
                }
            }
            catch { throw; }
            return _res;
        }
    }
}