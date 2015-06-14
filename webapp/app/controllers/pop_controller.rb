class PopController < ApplicationController
  # before_action :set_pop, only: [:show, :edit, :update, :destroy]

  def index
    # @pops = Pop.all
    # respond_to do |format|
    #   valid = %w(pop)
    #   if valid.include?(params[:path])
    #     # @pops = Pop.all
    #     format.html{ render :template => File.join('pop', params[:path]) }
    #   else
    #     render :file => File.join(Rails.root, 'public', '404.html'),
    #            :status => 404
    #   end
    # end
  end

  def new
    if request.post?
      # @pop = Pop.new { name: params[:name], X: params[:X], Y: params[:Y], Z: paramas[:Z] }
      # format.json { render json: }
    end
  end

  def show
  end

  def create
    # valid = %w(pop)
    @pop = Pop.new(pop_params)

    respond_to do |format|
      if @pop.save
        #format.html { notice: 'Pop was successfully created.' }
        format.json { render :show, status: :created }
      else
        format.html { render :new }
        format.json { render json: @pop.errors, status: :unprocessable_entity }
      end
    end
  end

  def destroy
    @pop.destroy
    respond_to do |format|
      format.html { redirect_to users_url, notice: 'Pop was successfully destroyed.' }
      format.json { head :no_content }
    end
  end

  private
    # Use callbacks to share common setup or constraints between actions.
    def set_pop
      @pop = Pop.find(params[:id])
    end

    # Never trust parameters from the scary internet, only allow the white list through.
    def pop_params
      params.require(:pop).permit(:email, :nick, :pass_hash, :pass_salt)
    end
end