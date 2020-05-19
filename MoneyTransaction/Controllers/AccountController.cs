using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoneyTransaction.DataAccess.Models;
using MoneyTransaction.Service.Repositories;

namespace MoneyTransaction.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private IAccountRepository _accountRepository;

        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        // GET: api/Account
        [HttpGet]
        [ProducesResponseType(typeof(List<Account>), 200)]
        public async Task<ActionResult> Get()
        {
            var accounts = await _accountRepository.GetAllAsync();
            return Ok(accounts);
        }

        // GET: api/Account/5
        [HttpGet("{id}", Name = "Get")]
        [ProducesResponseType(typeof(Account), 200)]
        public async Task<ActionResult> Get(Guid id)
        {
            var account = await _accountRepository.GetByIdAsync(id);
            if (account == null)
                return NotFound();
            return Ok(account);
        }

        // POST: api/Account
        [HttpPost]
        [ProducesResponseType(typeof(Account), 201)]
        [ProducesResponseType(typeof(string), 400)]
        public async Task<ActionResult> Post([FromBody] Account model)
        {
            if (!ModelState.IsValid)
                return BadRequest(this.ModelState);

            var newAccount = await _accountRepository.InsertAsync(model);
            if (newAccount == null)
                return BadRequest("Account could not be created.");
            return CreatedAtRoute("Get", new { id = newAccount.Id }, newAccount);
        }

        // PUT: api/Account/5
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
        }
    }
}
