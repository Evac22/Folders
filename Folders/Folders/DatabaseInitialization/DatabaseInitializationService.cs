using Folders.Context;
using Folders.Models;

namespace Folders.DatabaseInitialization
{
    public static class DatabaseInitializationService
    {
        public static void InitializeDatabase(ApplicationDbContext context)
        {
            if (!context.Folders.Any())
            {
                var rootFolder = new Folder { Name = "Creating Digital Images" };
                context.Folders.Add(rootFolder);
                context.SaveChanges();

                var resourcesFolder = new Folder { Name = "Resources", ParentFolderId = rootFolder.Id };
                var evidenceFolder = new Folder { Name = "Evidence", ParentFolderId = rootFolder.Id };
                var graphicProductsFolder = new Folder { Name = "Graphic Products", ParentFolderId = rootFolder.Id };

                context.Folders.AddRange(resourcesFolder, evidenceFolder, graphicProductsFolder);
                context.SaveChanges();

                var primarySourcesFolder = new Folder { Name = "Primary Sources", ParentFolderId = resourcesFolder.Id };
                var secondarySourcesFolder = new Folder { Name = "Secondary Sources", ParentFolderId = resourcesFolder.Id };

                context.Folders.AddRange(primarySourcesFolder, secondarySourcesFolder);
                context.SaveChanges();

                var processFolder = new Folder { Name = "Process", ParentFolderId = graphicProductsFolder.Id };
                var finalProductFolder = new Folder { Name = "Final Product", ParentFolderId = graphicProductsFolder.Id };

                context.Folders.AddRange(processFolder, finalProductFolder);
                context.SaveChanges();
            }
        }

    }
}
