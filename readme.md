#Paul's .NET DDD Sample App


A highly opinionated port of the DDD sample app to C#.

Intended tools:

* VS2010
* Nunit
* RavenDB
* Backbone.js
* SpecFlow
* ?

To do:

* Implement Rx for Aggregate updating
 * Install NuGet and Rx
* Features:
 * Implement cargo.IsReadyToClaim()
 * Implement cargo.IsMisdirected()
 * Implement cargo.EstimatedTimeOfArrival()
 * Implement cargo.NextExpectedActivity()
 * Add arrival deadline to route specification
 * Fix syntax for extension method - this is weird!
 * Improve value object handling