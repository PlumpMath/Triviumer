# Place all the behaviors and hooks related to the matching controller here.
# All this logic will automatically be available in application.js.
# You can use CoffeeScript in this file: http://coffeescript.org/
console.debug 'webgl.coffee loaded'

#showPop = (data)->
#  for d in data
#    window.SendMessage 'InputField', 'Submit', d.name

###
window.initUnity = ->
  u = new UnityObject2()
  u.observeProgress (progress) ->
    $missingScreen = $(progress.targetEl).find('.missing')
    switch progress.pluginStatus
      when 'unsupported', 'broken' then alert 'error'
      when 'missing' then
        $missingScreen.find('a').click (e) ->
          e.stopPropagation()
          e.preventDefault()
          u.installPlugin()
#          return false
#        $missingScreen.show()
      when 'installed' then $missingScreen.remove()
    $ ->
      u.initPlugin $('#unityPlayer')[0], 'Triviumer.unity3d'###
