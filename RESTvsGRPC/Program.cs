﻿using BenchmarkDotNet.Running;
using RESTvsGRPC;

BenchmarkRunner.Run<BenchmarkHarness>();
Console.ReadKey();