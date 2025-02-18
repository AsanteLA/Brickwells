namespace BrickWells.Models.ViewModels;

public class BrickListViewModel
{
    public IQueryable<Product> Products { get; set; }
    
    public PaginationInfo PaginationInfo { get; set; } = new PaginationInfo();
    
    public string? currentCategory { get; set; }
    
    
    // public Cart Cart { get; set; } = new Cart();
    
    // public List<Product> Product { get; set; }
    
    
}