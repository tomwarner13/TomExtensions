namespace TomExtensions.Loops;

public static class Repeaters
{
  public static void Repeat(int n, Action action) {
    for(var i = 0; i < n; i++) {
      action();
    }
  }
	
  public static void Repeat(int n, Action<int> action) {
    for(var i = 0; i < n; i++) {
      action(i);
    }
  }
}
