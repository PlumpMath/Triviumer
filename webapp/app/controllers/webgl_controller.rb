class WebglController < ApplicationController
  # layout 'webgl'
  # cache :show
  def show
    valid = %w(webgl)
    if valid.include?(params[:path])
      render :template => File.join('webgl', params[:path])
    elsif params?

    else
      render :file => File.join(Rails.root, 'public', '404.html'),
             :status => 404
    end
  end
  def index

  end
  def test
    render js: 'alert("testing");'
  end
end