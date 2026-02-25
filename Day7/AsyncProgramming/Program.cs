using System.Diagnostics;

await TaskParallelDemoAsync();
// await TaskDemoAsync();

async Task TaskParallelDemoAsync()
{
    using var _client = new HttpClient();

    var urls = Enumerable.Range(1, 10)
        .Select(i => $"https://jsonplaceholder.typicode.com/posts/{i}")
        .ToList();

    var stopwatch = Stopwatch.StartNew();

    var downloadTasks = urls.Select(async url =>
    {
        var threadBefore = Thread.CurrentThread.ManagedThreadId;

        string content = await _client.GetStringAsync(url);

        var threadAfter = Thread.CurrentThread.ManagedThreadId;

        Console.WriteLine($"Thread Before: {threadBefore} downloading {url}. ({content.Length} chars) [Thread After {threadAfter}]");

        return content;

    });

    string[] results = await Task.WhenAll(downloadTasks);

    stopwatch.Stop();
    Console.WriteLine($"\nTotal time: {stopwatch.ElapsedMilliseconds}ms");
}

async Task TaskDemoAsync()
{
    using var _client = new HttpClient();

    var urls = Enumerable.Range(1, 10)
        .Select(i => $"https://jsonplaceholder.typicode.com/posts/{i}")
        .ToList();

    var stopwatch = Stopwatch.StartNew();

    foreach (var url in urls)
    {
        var threadBefore = Thread.CurrentThread.ManagedThreadId;

        Console.Write($"[Thread {threadBefore}] Fetching {url}... ");

        string content = await _client.GetStringAsync(url);

        var threadAfter = Thread.CurrentThread.ManagedThreadId;

        Console.WriteLine($"done. ({content.Length} chars) [Thread {threadAfter}]");
    }

    stopwatch.Stop();
    Console.WriteLine($"\nTotal time: {stopwatch.ElapsedMilliseconds}ms");
}


// void ThreadDemo()
// {
//     using var _client = new HttpClient();

//     var urls = Enumerable.Range(1, 10)
//         .Select(i => $"https://jsonplaceholder.typicode.com/posts/{i}")
//         .ToList();

//     var stopwatch = Stopwatch.StartNew();

//     foreach (var url in urls)
//     {
//         int threadId = Thread.CurrentThread.ManagedThreadId;

//         Console.Write($"[Thread {threadId}] Fetching {url}... ");

//         var response = _client.GetAsync(url).Result;
//         var content = response.Content.ReadAsStringAsync().Result;

//         Console.WriteLine($"done. ({content.Length} chars)");
//     }

//     stopwatch.Stop();
//     Console.WriteLine($"\nTotal time: {stopwatch.ElapsedMilliseconds}ms");

// }