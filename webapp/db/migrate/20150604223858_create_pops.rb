class CreatePops < ActiveRecord::Migration
  def change
    create_table :pops do |t|

      t.timestamps null: false
    end
  end
end
