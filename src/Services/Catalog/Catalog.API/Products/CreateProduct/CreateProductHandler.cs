namespace Catalog.API.Products.CreateProduct
{
    public record CreateProductCommand(string Name, string Description, List<string> Category, string ImageFile, decimal Price): ICommand<CreateProductResult>;
    public record CreateProductResult(Guid Id);

    //Validation Class
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    { 
    public CreateProductCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is Required");
            RuleFor(x => x.Category).NotEmpty().WithMessage("Category is Required");
            RuleFor(x => x.ImageFile).NotEmpty().WithMessage("ImageFile is Required");
            RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price Must be greater than 0.");
        }
    }
    internal class CreateProductCommandHandler(IDocumentSession session) : ICommandHandler<CreateProductCommand, CreateProductResult>
    {
        public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            //Business logic to create product

            //Create product entity from command

            var product = new Product
            {
                Name = command.Name,
                Description = command.Description,
                Category = command.Category,
                ImageFile = command.ImageFile,
                Price = command.Price
            };
             
            //Save the details in DB

            session.Store(product);
            await session.SaveChangesAsync(cancellationToken);
            //Return Result CreateProductResult obj
            return new CreateProductResult(product.Id);
        }
    }
}
