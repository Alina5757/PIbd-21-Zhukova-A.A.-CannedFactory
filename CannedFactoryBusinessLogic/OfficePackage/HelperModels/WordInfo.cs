using CannedFactoryContracts.ViewModels;
using System.Collections.Generic;

namespace CannedFactoryBusinessLogic.OfficePackage.HelperModels
{
    public class WordInfo
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public List<CannedViewModel> Canneds { get; set; }
    }
}
