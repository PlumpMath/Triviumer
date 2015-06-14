# Place all the behaviors and hooks related to the matching controller here.
# All this logic will automatically be available in application.js.
# You can use CoffeeScript in this file: http://coffeescript.org/
console.debug 'pop.coffee loaded'

window.newPop = (name, x, y, z)->
  console.log "#{name} have created on #{x}, #{y}, #{z}"
  $.post '/pop/create', {
      pop: {
        name: name
        X: x
        Y: y
        Z: z
      }
    },
    (rst) =>
      console.log rst

window.newCon = (name, sid, eid) ->
  console.debug name, sid, eid

$.getJSON '/pop/?callback=?',{
  data: {
    callback: loadPops
  }
}
loadPops = (data) ->
  console.debug data
  for d in data
    console.debug d
    SendMessage('InputField', 'GoTo', data.X, data.Y, data.Z)
    SendMessage('InputField', 'newPop', data.ID, data.name)
#if UnityObject2?
#  window.u = u = new UnityObject2()
#  u.initPlugin(jQuery('#unityPlayer')[0], 'Triviumer.unity3d')
#  u.observeProgress (progress) ->'
#    $missingScreen = $(progress.targetEl).find('.missing')
#    console.debug progress.pluginStatus
#    switch progress.pluginStatus
#      when 'unsupported', 'broken' then alert 'error'
#      when 'missing' then
#        $missingScreen.find('a').click (e) ->
#          e.stopPropagation()
#          e.preventDefault()
#          u.installPlugin()
#          false
  #          return false
#        $missingScreen.show()
#      when 'installed' then $missingScreen.remove()
#    $ ->
#      u.initPlugin $('#unityPlayer')[0], 'Triviumer.unity3d'