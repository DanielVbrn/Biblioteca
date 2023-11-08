using Microsoft.AspNetCore.Mvc;
using Livraria.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Livraria.Controllers
{
    [Route("Libraians")]
    public class LibraiansController : Controller
    {
        private List<Libraian> _librarians = new List<Libraian>();
        private List<Books> _books = new List<Books>();
        private List<Member> _members = new List<Member>();


        // Método para atualizar informações do bibliotecário
        [Route("UpdateInfo")]
            public IActionResult UpdateInfo(int id)
        {
            Libraian librarian = _librarians.FirstOrDefault(l => l.Id == id)?? new Libraian();

            if (librarian == null)
            {
                return NotFound();
            }

            // Simplesmente retorne o bibliotecário para a visualização
            return View(librarian);
        }

        // Método para pesquisar livros
        [Route("SearchBk")]
        public IActionResult SearchBk()
        {
            List<Books> availableBooks = _books.Where(b => string.IsNullOrEmpty(b.Notebooks)).ToList();

            return View(availableBooks);
        }

        // Método para emitir livros para membros
        [Route("IssueBooks/{memberId}")]
        public IActionResult IssueBooks(int memberId)
        {
            Member member = _members.FirstOrDefault(m => m.Id == memberId) ?? new Member();

            if (member == null)
            {
                return NotFound();
            }

            // Implemente a lógica para encontrar e emitir livros
            List<Books> booksToIssue = _books.Where(b => string.IsNullOrEmpty(b.Notebooks)).ToList();

            // Verifique se há livros disponíveis para emissão
            if (booksToIssue.Count == 0)
            {
                // Redirecione para uma página de erro ou exiba uma mensagem
                return View("Error"); // Substitua "Error" pelo nome da sua página de erro
            }

            // Suponha que você deseja emitir o primeiro livro disponível
            Books bookToIssue = booksToIssue.First();

            // Atualize o status do livro para indicar que foi emitido
            bookToIssue.Notebooks = "Issued"; // Você pode usar um status adequado

            // Registre o livro emitido na lista de livros do membro
            member.BooksIssued.Add(bookToIssue);

            // Salve as alterações, se necessário
            // Isso pode envolver atualizar um banco de dados ou uma lista em memória

            // Redirecione de volta para a página de informações do membro
            return RedirectToAction("MemberInfo", new { memberId = member.Id });
        }


        // Método para obter informações de um membro
        [Route("MemberInfo/{memberId}")]
        public IActionResult MemberInfo(int memberId)
        {
            Member member = _members.FirstOrDefault(m => m.Id == memberId)?? new Member();

            if (member == null)
            {
                return NotFound();
            }

            return View(member);
        }

        // Método para registrar a devolução de um livro
        [Route("ReturnBk/{memberId}")]
        public IActionResult ReturnBk(int memberId)
        {
            // Implemente a lógica para registrar a devolução do livro
            // Por exemplo, atualize o status do livro (campo Notebooks) para indicar que foi devolvido

            return View();
        }
    }
}
