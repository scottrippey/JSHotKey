(function() {

  var events = {
    onMouseMove: function(eventArgs) {
      console.log("Mouse Move", eventArgs);
    }
  };

  var edge = require('edge');

  var AddEvents = edge.func({
    assemblyFile: 'TestDotNetProject/TestDotNetProject/bin/Debug/TestDotNetProject.dll',
    typeName: 'TestDotNetProject.Main',
    methodName: 'AddEvents'
  });
  AddEvents(events, true);

  // Keep alive:
  process.stdin.resume();

})();
