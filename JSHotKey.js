(function() {

  var edge = require('edge');

  var main = {
    ToUpper: edge.func({
      assemblyFile: 'TestDotNetProject/TestDotNetProject/bin/Debug/TestDotNetProject.dll',
      typeName: 'TestDotNetProject.Main',
      methodName: 'ToUpper'
    })
  };

  main.ToUpper('Hello from Node.js', function (error, result) {
    console.log(result);
  });

})();
