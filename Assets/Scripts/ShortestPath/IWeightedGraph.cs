using System.Collections.Generic;
public interface IWeightedGraph<T>
{
    IEnumerable<(T node, int weight)> Neighbors(T node);
    IEnumerable<T> GetNodes();

}