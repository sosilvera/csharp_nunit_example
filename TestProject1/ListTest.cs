namespace Classes;

public class ListaTests
{
    [Test]
    public void getHead_EqualToPosition0()
    {
        int[] lista = [2,3,4]; // Arrange
        Lista l = new Lista(lista); // Arrange

        int result = l.getHead(); // Act

        Assert.That(actual: result, Is.EqualTo(expected: lista[0])); // Assert
    }

    [Test]
    public void getLast_EqualToPosition2()
    {
        int[] lista = [1,2,3];
        Lista l = new Lista(lista); // Arrange

        int result = l.getLast(); // Act

        Assert.That(actual: result, Is.EqualTo(expected: 3));
    }

    [Test]
    public void isVoid_noVoidArray_isFalse()
    {
        int[] lista = [1,2,3];
        Lista l = new Lista(lista);
        Assert.That(actual: l.isVoid(), Is.EqualTo(expected: false));
    }


    [Test]
    public void isVoid_VoidArray_isTrue()
    {
        int[] lista = [];
        Lista l = new Lista(lista); // Array

        bool result = l.isVoid();

        Assert.IsTrue(result, "La condicion no es verdadera");
        Assert.That(actual: l.isVoid(), Is.True);
    }    
}