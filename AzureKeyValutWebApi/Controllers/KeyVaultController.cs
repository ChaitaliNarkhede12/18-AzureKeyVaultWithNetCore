using Azure.Security.KeyVault.Secrets;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzureKeyValutWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KeyVaultController : ControllerBase
    {
        private readonly IKeyVaultManager _secretManager;
        //private readonly SecretClient _secretClient;
        public KeyVaultController(IKeyVaultManager secretManager)
        {
            _secretManager = secretManager;
            //_secretClient = secretClient;
        }

        [HttpGet("getSecret")]
        public async Task<IActionResult> GetSecretAsync()
        {
            string AppSecretValue = await _secretManager.GetSecret("demo");
            return Ok(AppSecretValue);

            //KeyVaultSecret keyValueSecret = await _secretClient.GetSecretAsync("AppSecret");
            //var result =  keyValueSecret.Value;
            // return Ok(result.ToString());
        }

    }
}
