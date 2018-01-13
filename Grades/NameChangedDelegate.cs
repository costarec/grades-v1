
namespace Grades
{
    // orig version doesn't follow convention
    //public delegate void NameChangedDelegate(string existingName, string newName);


    // new version follows event version - (event source, args)
    public delegate void NameChangedDelegate(object sender, NameChangedEventArgs args);

}
