using AutoMapper;
using LibraryManagement.Data;
using LibraryManagement.Models;
using LibraryManagement.Models.Dtos;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace LibraryManagement.Repository
{
    public class BookService : IBookService
    {
        private readonly LibraryDbContext context;
        private IMapper mapper;
        public BookService(LibraryDbContext dbContext, IMapper mapper)
        {
            context = dbContext;
            this.mapper = mapper;
        }

        public async Task<BookDto> AddNewBook(BookDto book)
        {
            var book1 = mapper.Map<Book>(book);
            await context.Books.AddAsync(book1);
            await context.SaveChangesAsync();
            return mapper.Map<BookDto>(book1);
        }

        public async Task<bool> DeleteBook(int id)
        {
            Book book = await context.Books.FirstOrDefaultAsync(x => x.BookId == id);
            if (book == null)
            {
                return false;
            }
            context.Books.Remove(book);
            context.SaveChangesAsync();
            return true;

        }

        public async Task<Book> GetBookById(int id)
        {
            Book book = await context.Books.FirstOrDefaultAsync(x => x.BookId == id);
            if (book == null)
            {
                return null;
            }
            return book;
        }

        public async Task<IEnumerable<BookDto>> GetBookByName(string name)
        {
            IEnumerable<Book> books = await context.Books.Where(x => x.Title.Contains(name)).ToListAsync();
            if (books == null)
            {
                return null;
            }
            return mapper.Map<List<BookDto>>(books);
        }

        public async Task<IEnumerable<BookDto>> GetBooks()
        {
            IEnumerable<Book> books = await context.Books.ToListAsync();
            IEnumerable<BookDto> booksList = mapper.Map<IEnumerable<BookDto>>(books);
            
            return booksList;
        }
        public async Task<Book> UpdateBook(int id, BookDto book)
        {
            var book1 = await context.Books.FirstOrDefaultAsync(x => x.BookId == id);
            var updatedBook = mapper.Map<Book>(book);
            if (book1 != null)
            {
                context.Entry(book1).State = EntityState.Detached;
                context.Books.Update(updatedBook);
                await context.SaveChangesAsync();
                return updatedBook;
            }
            return null;
        }
    }
}
